from abc import ABC, abstractmethod
from models import Artista

class IArtistaRepository(ABC):
    @abstractmethod
    async def get_by_id(self, id: str) -> Artista:
        pass
    
    @abstractmethod
    async def get_by_nombre(self, nombre: str) ->list:
        pass
    
    @abstractmethod
    async def create(self, artista: Artista) -> Artista:
        pass
    
    @abstractmethod
    async def update(self, artista: Artista) -> Artista:
        pass
    
    @abstractmethod 
    async def delete(self, artista: Artista) -> Artista:
        pass
    
    @abstractmethod 
    async def get_paginated(self, page: int, size: int) ->(list, int):
        pass
    