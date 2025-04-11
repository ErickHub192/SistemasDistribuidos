from fastapi import APIRouter, HTTPException, Query, Depends
from Dtos.schemas import Artista, ArtistaCreate, ArtistaUpdate, PaginatedArtistas
from services.artistasService import ArtistaServiceAsync
from security.security import require_scope
router = APIRouter()
service = ArtistaServiceAsync()

@router.get("/paginated", response_model=PaginatedArtistas)
async def get_artistas_paginated(page: int = Query(1, ge=1), size: int = Query(10, ge=1),user: dict = Depends(require_scope("Read"))):
    paginated_data = await service.get_artistas_paginated(page, size)
    return paginated_data

@router.get("/", response_model=list[Artista])
async def get_artistas_by_nombre(nombre: str = Query(..., min_length=1),user: dict = Depends(require_scope("Read"))):
    artistas = await service.get_artista_by_nombre(nombre)
    return artistas

@router.get("/{id}", response_model=Artista)
async def get_artista_by_id(id: str,user: dict = Depends(require_scope("Read"))):
    artista = await service.get_artista_by_id(id)
    if not artista:
        raise HTTPException(status_code=404, detail="Artista no encontrado")
    return artista

@router.post("/", response_model=Artista, status_code=201)
async def create_artista(artista: ArtistaCreate, user: dict = Depends(require_scope("Write"))):
    new_artista = await service.create_artista(artista.dict())
    return new_artista

@router.put("/{id}", response_model=Artista)
async def update_artista(id: str, artista: ArtistaUpdate,user: dict = Depends(require_scope("Write"))):
    updated_artista = await service.update_artista(id, artista.dict(exclude_unset=True))
    return updated_artista

@router.delete("/{id}", status_code=204)
async def delete_artista_by_id(id: str, user: dict = Depends(require_scope("Write"))):
    success = await service.delete_artista(id)
    if not success:
        raise HTTPException(status_code=404, detail="Artista no encontrado")
    return
