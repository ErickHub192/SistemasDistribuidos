import math
from sqlalchemy.future import select
from sqlalchemy import func
from models import Artista
from db import async_session
from repositories.artistasRepository import ArtistaRepositoryAsync
from exceptions import ArtistaConflictException, ArtistaValidationException
from mappers.artistasMapper import artista_to_dto, dto_to_artista
from services.IArtistaService import IArtistaService

class ArtistaServiceAsync(IArtistaService):
    def __init__(self, repository=None):
        self.repository = repository if repository else ArtistaRepositoryAsync()

    async def get_artista_by_id(self, id: str):
        artista = await self.repository.get_by_id(id)
        if not artista:
            return None
        return artista_to_dto(artista)

    async def get_artista_by_nombre(self, nombre: str):
        artistas = await self.repository.get_by_nombre(nombre)
        return [artista_to_dto(a) for a in artistas]

    async def create_artista(self, data: dict):
        if not data.get("nombre"):
            raise ArtistaValidationException("El nombre es requerido")
        existing = await self.repository.get_by_nombre(data.get("nombre"))
        if existing:
            raise ArtistaConflictException("El Artista ya existe")
        artista = dto_to_artista(data)
        created = await self.repository.create(artista)
        return artista_to_dto(created)

    async def update_artista(self, id: str, data: dict):
        artista = await self.repository.get_by_id(id)
        if not artista:
            raise ArtistaValidationException("Artista no encontrado")
        if "nombre" in data:
            artistas_con_nombre = await self.repository.get_by_nombre(data.get("nombre"))
            for a in artistas_con_nombre:
                if a.id != id:
                    raise ArtistaConflictException("Ya existe un Artista con ese nombre")
        artista = dto_to_artista(data, artista)
        updated = await self.repository.update(artista)
        return artista_to_dto(updated)

    async def delete_artista(self, id: str):
        artista = await self.repository.get_by_id(id)
        if not artista:
            return False
        return await self.repository.delete(artista)
    
    async def get_artistas_paginated(self, page: int, size: int):
        artistas, total = await self.repository.get_paginated(page, size)
        data = [artista_to_dto(a) for a in artistas]
        pages = math.ceil(total / size)
        return {
            "total": total,
            "pages": pages,
            "current_page": page,
            "data": data
        }
