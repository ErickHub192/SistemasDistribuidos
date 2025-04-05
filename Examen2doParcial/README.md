# API de Artistas con FastAPI

## Descripción
Esta API REST permite gestionar registros de artistas y soporta operaciones CRUD (Crear, Leer, Actualizar, Eliminar) y un endpoint de paginación.

## Requisitos
- Docker y Docker Compose instalados.
- Postman o navegador para probar Swagger (disponible en `/docs`).

## Instalación y Ejecución

1. Clonar el repositorio.
2. En el directorio raíz del proyecto, ejecutar: docker-compose up --build

3. La API estará disponible en `http://localhost:5000`.
4. La documentación interactiva de Swagger se encuentra en `http://localhost:5000/docs`.

## Endpoints
- `GET /api/v1/artistas/{id}`: Obtiene un artista por ID.
- `GET /api/v1/artistas?nombre=...`: Busca artistas por nombre.
- `POST /api/v1/artistas`: Crea un nuevo artista.
- `PUT /api/v1/artistas/{id}`: Actualiza un artista por ID.
- `DELETE /api/v1/artistas/{id}`: Elimina un artista por ID.
- `GET /api/v1/artistas/paginated?page={page}&size={size}`: Obtiene artistas con paginación.

## Ejemplos de peticiones

### Crear Artista
POST /api/v1/artistas Content-Type: application/json
{ "nombre": "Artista Ejemplo", "genero": "Pop", "edad": 30 }

### Obtener Artista por ID
GET /api/v1/artistas/{id}

shell
Copiar

### Actualizar Artista
PUT /api/v1/artistas/{id} Content-Type: application/json

{ "nombre": "Artista Actualizado", "genero": "Rock" }

shell
Copiar

### Eliminar Artista
DELETE /api/v1/artistas/{id}

shell
Copiar

### Paginación
GET /api/v1/artistas/paginated?page=1&size=10

## Base de Datos

La API utiliza MySQL y SQLAlchemy para la conexión. La URL de conexión se configura mediante la variable de entorno `DEFAULT_CONNECTION`.

