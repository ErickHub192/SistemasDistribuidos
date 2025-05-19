
from abc import ABC, abstractmethod
from typing import List, Optional
from models.trainer import Trainer

class ITrainerRepository(ABC):
    @abstractmethod
    async def get_by_id(self, id: str) -> Optional[Trainer]:
        """
        Get By Id
        """
        ...

    @abstractmethod
    async def create(self, trainer: Trainer) -> Trainer:
        """
        Crear un nuevo Trainer.
        """
        ...

    @abstractmethod
    async def get_by_name(self, name: str) -> List[Optional[Trainer]]:
        """
        Get By Name
        """
        ...
