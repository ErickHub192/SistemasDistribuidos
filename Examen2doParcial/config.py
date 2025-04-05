import os

class Config:
    SQLALCHEMY_DATABASE_URI = os.getenv(
        "DEFAULT_CONNECTION",
        "mysql+asyncmy://pika:pass@mysql-container:3306/DistributedSystems"
    )
    SQLALCHEMY_TRACK_MODIFICATIONS = False

config = Config()
