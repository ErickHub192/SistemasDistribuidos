from sqlalchemy.future import select
from sqlalchemy import func
from models import Artista
from db import async_session
from repositories.IArtistaRepository import IArtistaRepository

class ArtistaRepositoryAsync(IArtistaRepository):
    async def get_by_id(self, id: str):
        async with async_session() as session:
            result = await session.execute(select(Artista).where(Artista.id == id))
            return result.scalars().first()

    async def get_by_nombre(self, nombre: str):
        async with async_session() as session:
            result = await session.execute(
                select(Artista).where(Artista.nombre.ilike(f"%{nombre}%"))
            )
            return result.scalars().all()

    async def create(self, artista: Artista):
        async with async_session() as session:
            session.add(artista)
            await session.commit()
            await session.refresh(artista)
            return artista

    async def update(self, artista: Artista):
        async with async_session() as session:
            session.add(artista)
            await session.commit()
            await session.refresh(artista)
            return artista

    async def delete(self, artista: Artista):
        async with async_session() as session:
            await session.delete(artista)
            await session.commit()
            return True
        
    async def get_paginated(self, page: int, size: int):
        async with async_session() as session:
            offset = (page - 1) * size
            query = select(Artista).offset(offset).limit(size)
            result = await session.execute(query)
            artistas = result.scalars().all()
            
            count_query = select(func.count()).select_from(Artista)
            total_result = await session.execute(count_query)
            total = total_result.scalar_one()
            return artistas, total
