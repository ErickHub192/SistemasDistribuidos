# config.py

import os
from dataclasses import dataclass

@dataclass
class MongoDBSettings:
    connection_string: str
    database_name:     str
    collection_name:   str

    @classmethod
    def from_env(cls) -> "MongoDBSettings":
        return cls(
            connection_string = os.getenv("MongoDB__ConnectionString"),
            database_name     = os.getenv("MongoDB__DatabaseName"),
            collection_name   = os.getenv("MongoDB__TrainerCollectionName"),
        )