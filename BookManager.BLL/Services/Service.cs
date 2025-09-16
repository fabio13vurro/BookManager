using AutoMapper;
using BookManager.BLL.Interfaces;
using BookManager.DAL.Interfaces;


namespace BookManager.BLL.Services
{
    public class Service<Entity, Model> : IService<Model> where Entity : class where Model : class
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public Service(IMapper mapper, IRepository<Entity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Add(Model entity)
        {
            var newEntity = _mapper.Map<Entity>(entity);
            _repository.Add(newEntity);
            _repository.SaveChanges();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public IEnumerable<Model> GetAll()
        {
            var entities = _repository.GetAll();
            var models = _mapper.Map<IEnumerable<Model>>(entities);
            return models;
        }

        public Model GetById(int id)
        {
            var entity = _repository.GetById(id);
            var model = _mapper.Map<Model>(entity);
            return model;
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public void Update(Model entity)
        {
            // Prova con diversi nomi comuni per l'ID
            var idProperty = typeof(Model).GetProperty("Id");

            if (idProperty == null)
                throw new InvalidOperationException("Model must have an Id property");

            // Debug: stampa il valore per verificare
            var idValue = idProperty.GetValue(entity);
            Console.WriteLine($"ID value: {idValue}");

            var existingEntity = _repository.GetById((int)idValue);
            if (existingEntity == null)
                throw new ArgumentException($"Entity with ID {idValue} not found");

            _mapper.Map(entity, existingEntity);
            _repository.Update(existingEntity);
            _repository.SaveChanges();
        }
    }
}