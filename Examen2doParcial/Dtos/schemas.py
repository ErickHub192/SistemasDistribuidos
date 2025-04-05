from typing import List, Optional
from pydantic import BaseModel, constr

class ArtistaBase(BaseModel):
    nombre: constr(min_length=1)
    genero: Optional[str] = None
    edad: Optional[int] = None

class ArtistaCreate(ArtistaBase):
    pass

class ArtistaUpdate(ArtistaBase):
    pass

class Artista(ArtistaBase):
    id: str

    class Config:
        orm_mode = True

class PaginatedArtistas(BaseModel):
    total: int
    pages: int
    current_page: int
    data: List[Artista]
