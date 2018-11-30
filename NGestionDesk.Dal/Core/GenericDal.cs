using NGestionDesk.Common.Entity;
using NGestionDesk.Common.Interface;
using NGestionDesk.Dal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGestionDesk.Dal.Core
{
    public class GenericDal<Entity>
        where Entity : IEntity
    {
        protected int number;
        protected XmlDalSerializer dal;
        protected List<Entity> lista;
        protected int maxId;

        public GenericDal()
        {
            this.dal = new XmlDalSerializer(string.Format("{0}.xml", typeof(Entity).Name));
        }

        public GenericDal(int number)
        {
            this.number = number;
            this.dal = new XmlDalSerializer(string.Format("{0}_{1}.xml", typeof(Entity).Name, number));
        }

        public void Cargar()
        {
            this.lista = this.dal.Load<List<Entity>>();
            if (this.lista == null) this.lista = new List<Entity>();
            this.maxId = this.lista.Count == 0 ? 1 : this.lista.Max(m => m.Id) + 1;
        }

        private int ObtenerNuevoId()
        {
            var id = this.maxId;
            this.maxId++;
            return id;
        }

        public int AgregarEditar(Entity entity)
        {
            if (entity.Id == 0)
            {
                entity.Id = this.ObtenerNuevoId();
                this.lista.Add(entity);
            }
            else
            {
                var e = this.lista.FirstOrDefault(i => i.Id == entity.Id);
                if(e == null)
                {
                    throw new Exception(string.Format("La entidad '{0}' que se intenta actualizar no existe el Id '{1}'", typeof(Entity).Name, entity.Id));
                }
                var index = this.lista.IndexOf(e);
                this.lista.Remove(e);
                this.lista.Insert(index, entity);
            }

            this.dal.Save<List<Entity>>(this.lista);

            return entity.Id;
        }

        public Entity Obtener(int id)
        {
            return this.lista.FirstOrDefault(m => m.Id == id);
        }

        public List<Entity> ObtenerLista()
        {
            return this.lista;
        }

        public void Eliminar(Entity entity)
        {
            if (entity.Id == 0)
            {
                throw new Exception(string.Format("La entidad '{0}' que se intenta eliminar no tiene Id", typeof(Entity).Name));
            }

            var e = this.lista.FirstOrDefault(i => i.Id == entity.Id);
            if (e == null)
            {
                throw new Exception(string.Format("La entidad '{0}' que se intenta eliminar no existe el Id '{1}'", typeof(Entity).Name, entity.Id));
            }
            var index = this.lista.IndexOf(e);
            this.lista.Remove(e);

            this.dal.Save<List<Entity>>(this.lista);
        }
    }
}
