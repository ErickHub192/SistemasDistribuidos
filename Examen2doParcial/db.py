from sqlalchemy.ext.asyncio import create_async_engine, AsyncSession
from sqlalchemy.orm import sessionmaker
from config import config  

engine = create_async_engine(config.SQLALCHEMY_DATABASE_URI, echo=True)
async_session = sessionmaker(engine, expire_on_commit=False, class_=AsyncSession)
