# Base image
FROM python:3.11-slim

# Evitar buffering en logs
ENV PYTHONUNBUFFERED=1

# Directorio de trabajo
WORKDIR /app

# 1) Copiamos e instalamos las dependencias
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# 2) Copiamos el código completo
COPY . .

# 3) Exponemos el puerto gRPC
EXPOSE 50051

# 4) Arrancamos el servidor en modo sin buffer
CMD ["python", "-u", "main.py"]