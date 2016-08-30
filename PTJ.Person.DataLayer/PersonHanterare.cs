using PTJ.Base.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.DataLayer
{
    public class PersonHanterare : Base<int, Person, DBPersonDataContext, int, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public enum Relations
        {
            Adress,
        }

        public PersonHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            timeView = DateTime.Now;
            ctx = new DBPersonDataContext();
            lstResults = new List<Person>();
            result = new Person();
        }

        public List<Person> GetAll()
        {
            return base.getAll();
        }

        protected override List<Person> all()
        {
            return ctx.Persons.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView) == true).OrderBy(s => s.Efternamn + ":" + s.MellanNamn + ";" + s.FörNamn).ToList();
        }

        public bool Exists(List<Person> lstItems)
        {
            return base.exists(lstItems);
        }

        protected override bool existsItems(List<Person> lstItems)
        {
            return (from a in ctx.Persons
                    where lstItems.Select(s => s.Efternamn.Trim() + ", " + s.MellanNamn.Trim() + ", " + s.FörNamn.Trim().ToLower()).Contains(a.Efternamn.Trim() + ", " + a.MellanNamn.Trim() + ", " + a.FörNamn.Trim().ToLower())
                    select a).Count() > 0;
        }

        public bool Exists(List<int> lstIds)
        {
            return base.exists(lstIds);
        }

        protected override bool existsItems(List<int> lstIds)
        {
            return (from a in ctx.Persons
                    where lstIds.Select(s => s).Contains(a.Id)
                    select a).Count() > 0;
        }

        public Person GetById(int id)
        {
            return base.getById(id);
        }

        protected override Person byId(int id)
        {
            return ctx.Persons.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView)).Single(s => s.Id == id);
        }

        public List<Person> GetByName(string name)
        {
            return base.getBy1(name);
        }

        protected override List<Person> by1(object value)
        {
            return ctx.Persons
                        .Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView))
                        .Where(w => (w.Efternamn.Trim() + ", " + w.MellanNamn.Trim() + ", " + w.FörNamn.Trim()).ToLower().IndexOf(value.ToString().ToLower()) > -1)
                        .OrderBy(o => (o.Efternamn.Trim() + ", " + o.MellanNamn.Trim() + ", " + o.FörNamn.Trim()).ToLower()).ToList();
        }

        public object GetByRelation(Relations relation, int id)
        {
            return base.getByRelation(relation, id);
        }

        protected override bool isRelation1(string relation)
        {
            return Relations.Adress.ToString() == relation;
        }

        protected override object getRelation1(int id)
        {
            return (from a in ctx.Persons
                    join b in ctx.Adresses on a.Id equals b.Person_FKID
                    where b.Id == id
                    select new Base.Schemas.KeyValue<Person, Adress>() { Key = a, Value = b }).Distinct().ToList();
        }

        public List<Person> Add(List<Person> lstItems)
        {
            return base.add(lstItems);
        }

        protected override List<Person> addItems(List<Person> lstItems)
        {
            int newId = getNewId();
            lstItems.ForEach(f => f.Id = newId++);
            lstItems.ForEach(f => f.SkapadDatum = DateTime.Now); lstItems.ForEach(f => f.UpdateradDatum = DBDateTimeHelper.getDefaultDateTime());

            ctx.Persons.InsertAllOnSubmit(lstItems);
            ctx.SubmitChanges();
            return lstItems;
        }

        private int getNewId()
        {
            int Id = 1;
            if (ctx.Mails.Count() != 0)
            {
                Id = ctx.Mails.Select(s => s.Id).Max() + 1;
            }
            return Id;
        }

        public List<Person> Update(List<Person> lstItems)
        {
            return base.update(lstItems);
        }

        protected override List<Person> updateItems(List<Person> lstItems)
        {
            List<Person> lstPersonResult = new List<Person>();
            foreach (var item in (from au in ctx.Persons
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.FörNamn = updateItem.FörNamn;
                item.MellanNamn = updateItem.MellanNamn;
                item.Efternamn = updateItem.Efternamn;
                item.PersonNummer = updateItem.PersonNummer;
                item.UpdateradDatum = DateTime.Now;
                lstPersonResult.AddRange(this.Add(new List<Person>() { item }));
            }
            ctx.SubmitChanges();
            return lstPersonResult;
        }

        public List<Person> Delete(List<Person> lstItems)
        {
            return base.delete(lstItems);
        }

        protected override List<Person> deleteItems(List<Person> lstItems)
        {
            List<Person> lstPersonResult = new List<Person>();
            foreach (var item in (from au in ctx.Persons
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.FörNamn = updateItem.FörNamn;
                item.MellanNamn = updateItem.MellanNamn;
                item.Efternamn = updateItem.Efternamn;
                item.PersonNummer = updateItem.PersonNummer;
                item.UpdateradDatum = DateTime.Now;
            }
            ctx.SubmitChanges();
            return lstItems;
        }
    }
}
