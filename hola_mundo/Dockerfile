# Usa una imagen base de Python
FROM python:3.9-slim

# Establece el directorio de trabajo en el contenedor
WORKDIR /app

# Copia los archivos del proyecto al contenedor
COPY . .

# Instala las dependencias necesarias
RUN pip install flask

# Expone el puerto que usará Flask
EXPOSE 5000

# Comando para ejecutar la aplicación
CMD ["python", "hola.py"]
