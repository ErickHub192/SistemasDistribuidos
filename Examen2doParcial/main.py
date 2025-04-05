from fastapi import FastAPI, Request, HTTPException
from fastapi.responses import JSONResponse
from routers import artistas
from exceptions import ArtistaConflictException, ArtistaValidationException, ArtistaNotFoundException
import uvicorn
import asyncio
from models import Base
from db import engine

app = FastAPI(
    title="API de Artistas GG",
    description="API REST para gestionar artistas, con CRUD y paginación.",
    version="1.0.0"
)
app.include_router(artistas.router, prefix="/api/v1/artistas", tags=["artistas"])

@app.exception_handler(ArtistaConflictException)
async def conflict_exception_handler(request: Request, exc: ArtistaConflictException):
    return JSONResponse(status_code=409, content={"message": exc.message})

@app.exception_handler(ArtistaValidationException)
async def validation_exception_handler(request: Request, exc: ArtistaValidationException):
    return JSONResponse(status_code=400, content={"message": exc.message})

@app.exception_handler(ArtistaNotFoundException)
async def not_found_exception_handler(request: Request, exc: ArtistaNotFoundException):
    return JSONResponse(status_code=404, content={"message": exc.message})

@app.get("/")
async def root():
    return {"message": "API asíncrona de Artistas funcionando"}

# Función para crear las tablas en la base de datos automáticamente
async def init_db():
    async with engine.begin() as conn:
        await conn.run_sync(Base.metadata.create_all)

# Evento de startup para crear las tablas al iniciar la aplicación
@app.on_event("startup")
async def on_startup():
    await init_db()

if __name__ == "__main__":
    uvicorn.run("main:app", host="0.0.0.0", port=8090)
