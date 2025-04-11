from fastapi import Depends, HTTPException, status, Security
from fastapi.security import HTTPBearer, HTTPAuthorizationCredentials
from jose import JWTError, jwt
from pydantic import BaseModel
from config import config

class TokenData(BaseModel):
    scopes: list[str] = []  
    
bearer_scheme = HTTPBearer()

def verify_jwt(token: str):
    try:
        payload = jwt.decode(
            token,
            config.JWT_SECRET_KEY,
            algorithms=[config.ALGORITHM],
            audience=config.VALID_AUDIENCE,
            issuer=config.ISSUER
        )
        # Extraemos el scope (o scopes)
        scopes = payload.get("scope")  # O payload.get("scopes")
        if not scopes:
            scopes = []
        elif isinstance(scopes, str):
            scopes = scopes.split()  # Asumiendo que viene separado por espacios
        token_data = TokenData(scopes=scopes)
        return payload, token_data
    except JWTError as e:
        raise HTTPException(
            status_code=status.HTTP_401_UNAUTHORIZED,
            detail="Token inválido o expirado",
            headers={"WWW-Authenticate": "Bearer"},
        ) from e

def get_current_user(credentials: HTTPAuthorizationCredentials = Security(bearer_scheme)):
    token = credentials.credentials
    payload, token_data = verify_jwt(token)
    return {"payload": payload, "token_data": token_data}

def require_scope(required_scope: str):
    def scope_dependency(user: dict = Depends(get_current_user)):
        token_data: TokenData = user["token_data"]
        if required_scope not in token_data.scopes:
            raise HTTPException(
                status_code=status.HTTP_403_FORBIDDEN,
                detail="No tienes permisos para realizar esta operación",
            )
        return user
    return scope_dependency
