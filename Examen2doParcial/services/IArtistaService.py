from abc import ABC, abstractmethod

class IArtistaService(ABC):
    @abstractmethod
    async def get_artista_by_id(self, id: str):
        pass
    
    @abstractmethod
    async def get_artista_by_nombre(self, nombre: str):
        pass
    
    @abstractmethod
    async def create_artista(self, data: dict):
        pass
    
    @abstractmethod
    async def update_artista(self, id: str, data: dict):
        pass
    
    @abstractmethod
    async def delete_artista(self, id: str):
        pass
    
    @abstractmethod
    async def get_artistas_paginated(self, page: int, size: int):
        pass
    