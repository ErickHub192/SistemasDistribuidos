import uuid
from sqlalchemy import Column, String, Integer
from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()

class Artista(Base):
    __tablename__ = "artistas"
    id = Column(String(36), primary_key=True, default=lambda: str(uuid.uuid4()))
    nombre = Column(String(100), nullable=False, unique=True)
    genero = Column(String(50), nullable=True)
    edad = Column(Integer, nullable=True)
    
    def __repr__(self):
        return f"<Artista {self.nombre}>"
