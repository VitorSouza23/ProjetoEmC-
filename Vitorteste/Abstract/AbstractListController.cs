using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitorteste.Abstract
{
    abstract class AbstractListController<T>
    {
        protected List<T> lista;

        public AbstractListController()
        {
            this.lista = new List<T>();
        }
        protected List<T> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        protected void AddElement(T element)
        {
            this.lista.Add(element);
        }

        protected bool RemoveElement(int index)
        {
            return this.lista.Remove(this.lista.ElementAt(index));
        }

        protected bool UpdateElement(int index, T novoElemento)
        {
            T element = this.lista.ElementAt(index);
            if (element != null)
            {
                this.lista.Insert(index, novoElemento);
                return true;
            }
            return false;
        }

        protected T GetElement(int index)
        {
            return this.lista.ElementAt(index);
        }

        public int ListSize()
        {
            return this.lista.Count;
        }


    }
}