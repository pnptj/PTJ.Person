using PTJ.Base.BusinessRules;
using PTJ.Person.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using PTJ;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.BusinessRules
{
    public class GatuAdressHanterare : Base<int, Person.DataLayer.GatuAdressHanterare, Person.DataLayer.GatuAdress, Person.DataLayer.Adress, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public GatuAdressHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            if (timeView != DateTime.MinValue) { obj = new Person.DataLayer.GatuAdressHanterare() { TimeView = base.TimeView }; }
            else { obj = new Person.DataLayer.GatuAdressHanterare(); }

            lstResults = new List<Person.DataLayer.GatuAdress>();
            result = new Person.DataLayer.GatuAdress();
            lstResults1 = new List<Base.Schemas.KeyValue<Person.DataLayer.GatuAdress, Person.DataLayer.Adress>>();
        }

        public List<Person.DataLayer.GatuAdress> GetAll()
        {
            return base.getAll();
        }

        protected override List<Person.DataLayer.GatuAdress> All()
        {
            return obj.GetAll();
        }

        public Person.DataLayer.GatuAdress GetById(int id)
        {
            return base.getById(id);
        }

        protected override Person.DataLayer.GatuAdress getById(int id)
        {
            return obj.GetById(id);
        }

        public List<Person.DataLayer.GatuAdress> getByAdress(string name)
        {
            return base.getBy1(name);
        }

        protected override List<Person.DataLayer.GatuAdress> By1(object variable)
        {
            return obj.GetByName(variable.ToString());
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.GatuAdress, Person.DataLayer.Adress>> GetByAdress(int id)
        {
            return base.getByObject1(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.GatuAdress, Person.DataLayer.Adress>> byObject1(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.GatuAdress, Person.DataLayer.Adress>>)obj.GetByRelation(Person.DataLayer.GatuAdressHanterare.Relations.Adress, ((int)itemId)));
        }

        public List<Person.DataLayer.GatuAdress> Add(List<Person.DataLayer.GatuAdress> items)
        {
            return base.add(items);
        }

        protected override List<Person.DataLayer.GatuAdress> addItems(List<Person.DataLayer.GatuAdress> items)
        {
            return obj.Add(items);
        }

        public List<Person.DataLayer.GatuAdress> Change(List<Person.DataLayer.GatuAdress> items)
        {
            return base.change(items);
        }

        protected override List<Person.DataLayer.GatuAdress> changeItems(List<Person.DataLayer.GatuAdress> items)
        {
            return obj.Update(items);
        }

        public List<Person.DataLayer.GatuAdress> Remove(List<Person.DataLayer.GatuAdress> items)
        {
            return base.remove(items);
        }

        protected override List<Person.DataLayer.GatuAdress> removeItems(List<Person.DataLayer.GatuAdress> items)
        {
            return obj.Delete(items);
        }

        protected override void setObjectTimeStamp()
        {
            if (base.isTimeViewSet())
            {
                obj.TimeView = base.TimeView;
            }
        }

        public override bool ItemsExists(List<Person.DataLayer.GatuAdress> items)
        {
            return obj.Exists(items);
        }

        public override bool ItemsExists(List<int> ids)
        {
            return obj.Exists(ids);
        }

        protected override void setMessageChannel()
        {
            obj.MsgChannel = base.msgChannel;
        }

        public override List<Base.MessageChannel.Message> getObjectMessages()
        {
            return obj.MsgChannel.Get();
        }
    }
}
