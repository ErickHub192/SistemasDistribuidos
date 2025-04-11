import os

class Config:
    
    SQLALCHEMY_DATABASE_URI = os.getenv(
        "DEFAULT_CONNECTION",
        "mysql+asyncmy://pika:pass@mysql-container:3306/DistributedSystems"
    )
    
    
    AUTHORITY = os.getenv("Authentication__Authority", "http://hydra-public:4444")
    ISSUER = os.getenv("Authentication__Issuer", "http://hydra-public:4444")
    VALID_AUDIENCE = os.getenv("Authentication__Audience", "artistas-api")
    JWT_SECRET_KEY = os.getenv("JWT_SECRET_KEY", "secreto_superseguro")
    ALGORITHM = os.getenv("JWT_ALGORITHM", "HS256")

config = Config()
