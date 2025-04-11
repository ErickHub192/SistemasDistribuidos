class ArtistaConflictException(Exception):
    def __init__(self, message="El Artista ya existe"):
        self.message = message
        super().__init__(self.message)


class ArtistaValidationException(Exception):
    def __init__(self, message="Datos inválidos para el Artista"):
        self.message = message
        super().__init__(self.message)


class ArtistaNotFoundException(Exception):
    def __init__(self, message="Artista no encontrado"):
        self.message = message
        super().__init__(self.message)
