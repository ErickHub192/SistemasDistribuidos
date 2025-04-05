def artista_to_dto(artista):
    return {
        "id": artista.id,
        "nombre": artista.nombre,
        "genero": artista.genero,
        "edad": artista.edad
    }

def dto_to_artista(data, artista=None):
    from models import Artista
    if artista is None:
        artista = Artista()
    artista.nombre = data.get("nombre", artista.nombre)
    artista.genero = data.get("genero", artista.genero)
    artista.edad = data.get("edad", artista.edad)
    return artista
