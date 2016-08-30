using PTJ.Base.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.DataLayer
{
    public class AdressHanterare : Base<int, Adress, DBPersonDataContext, int, int, int, int, int, Nothing, Nothing, Nothing>
    {
        public enum Relations
        {
            AdressVariant,
            AdressTyp,
            Telefon,
            GatuAdress,
            Mail,
            Person,
        }

        public AdressHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            timeView = DateTime.Now;
            ctx = new DBPersonDataContext();
            lstResults = new List<Adress>();
            result = new Adress();
        }

        public List<Adress> GetAll()
        {
            return base.getAll();
        }

        protected override List<Adress> all()
        {
            return ctx.Adresses.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView) == true).OrderBy(o => o.AdressTyp_FKID.ToString() + o.Person_FKID.ToString() + o.Organisation_FKID.ToString() + o.AdressVariant_FKID.ToString()).ToList();
        }

        public bool Exists(List<Adress> lstItems)
        {
            return base.exists(lstItems);
        }

        protected override bool existsItems(List<Adress> lstItems)
        {
            return (from a in ctx.Adresses
                    where lstItems.Select(s => s.AdressTyp_FKID.ToString() + s.Person_FKID.ToString() + s.Organisation_FKID.ToString() + s.AdressVariant_FKID.ToString().ToLower()).Contains(a.AdressTyp_FKID.ToString() + a.Person_FKID.ToString() + a.Organisation_FKID.ToString() + a.AdressVariant_FKID.ToString().ToLower())
                    select a).Count() > 0;
        }

        public bool Exists(List<int> lstIds)
        {
            return base.exists(lstIds);
        }

        protected override bool existsItems(List<int> lstIds)
        {
            return (from a in ctx.Adresses
                    where lstIds.Select(s => s).Contains(a.Id)
                    select a).Count() > 0;
        }

        public Adress GetById(int id)
        {
            return base.getById(id);
        }

        protected override Adress byId(int id)
        {
            return ctx.Adresses.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView)).Single(s => s.Id == id);
        }

        public object GetByRelation(Relations relation, int id)
        {
            return base.getByRelation(relation, id);
        }

        protected override bool isRelation1(string relation)
        {
            return Relations.AdressTyp.ToString() == relation;
        }

        protected override object getRelation1(int id)
        {
            return (from a in ctx.Adresses
                    join b in ctx.AdressTyps on a.AdressTyp_FKID equals b.Id
                    where b.Id == id
                    select new Base.Schemas.KeyValue<Adress, AdressTyp>() { Key = a, Value = b }).Distinct().ToList();
        }

        protected override bool isRelation2(string relation)
        {
            return Relations.AdressVariant.ToString() == relation;
        }

        protected override object getRelation2(int id)
        {
            return (from a in ctx.Adresses
                    join b in ctx.AdressVariants on a.AdressVariant_FKID equals b.Id
                    where b.Id == id
                    select new Base.Schemas.KeyValue<Adress, AdressVariant>() { Key = a, Value = b }).Distinct().ToList();
        }

        protected override bool isRelation3(string relation)
        {
            return Relations.GatuAdress.ToString() == relation;
        }

        protected override object getRelation3(int id)
        {
            return (from a in ctx.Adresses
                    join b in ctx.GatuAdresses on a.Id equals b.Adress_FKID
                    where b.Id == id
                    select new Base.Schemas.KeyValue<Adress, GatuAdress>() { Key = a, Value = b }).Distinct().ToList();
        }

        protected override bool isRelation4(string relation)
        {
            return Relations.Person.ToString() == relation;
        }

        protected override object getRelation4(int id)
        {
            return (from a in ctx.Adresses
                    join b in ctx.Persons on a.Person_FKID equals b.Id
                    where b.Id == id
                    select new Base.Schemas.KeyValue<Adress, Person>() { Key = a, Value = b }).Distinct().ToList();
        }

        protected override bool isRelation5(string relation)
        {
            return Relations.Telefon.ToString() == relation;
        }

        protected override object getRelation5(int id)
        {
            return (from a in ctx.Adresses
                    join b in ctx.Telefons on a.Id equals b.Adress_FKID
                    where b.Id == id
                    select new Base.Schemas.KeyValue<Adress, Telefon>() { Key = a, Value = b }).Distinct().ToList();
        }

        protected override bool isRelation6(string relation)
        {
            return Relations.Mail.ToString() == relation;
        }

        protected override object getRelation6(int id)
        {
            return (from a in ctx.Adresses
                    join b in ctx.Mails on a.Id equals b.Adress_FKID
                    where b.Id == id
                    select new Base.Schemas.KeyValue<Adress, Mail>() { Key = a, Value = b }).Distinct().ToList();
        }

        public List<Adress> Add(List<Adress> lstItems)
        {
            return base.add(lstItems);
        }

        protected override List<Adress> addItems(List<Adress> lstItems)
        {
            int newId = getNewId();
            lstItems.ForEach(f => f.Id = newId++);
            lstItems.ForEach(f => f.SkapadDatum = DateTime.Now); lstItems.ForEach(f => f.UpdateradDatum = DBDateTimeHelper.getDefaultDateTime());

            ctx.Adresses.InsertAllOnSubmit(lstItems);
            ctx.SubmitChanges();
            return lstItems;
        }

        private int getNewId()
        {
            int Id = 1;
            if (ctx.Adresses.Count() != 0)
            {
                Id = ctx.Adresses.Select(s => s.Id).Max() + 1;
            }
            return Id;
        }

        public List<Adress> Update(List<Adress> lstItems)
        {
            return base.update(lstItems);
        }

        protected override List<Adress> updateItems(List<Adress> lstItems)
        {
            List<Adress> lstAdressResult = new List<Adress>();
            foreach (var item in (from au in ctx.Adresses
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.AdressTyp_FKID = updateItem.AdressTyp_FKID;
                item.Person_FKID = updateItem.Person_FKID;
                item.Organisation_FKID = updateItem.Organisation_FKID;
                item.AdressVariant_FKID = updateItem.AdressVariant_FKID;
                item.UpdateradDatum = DateTime.Now;
                lstAdressResult.AddRange(this.Add(new List<Adress>() { item }));
            }
            ctx.SubmitChanges();
            return lstItems;
        }

        public List<Adress> Delete(List<Adress> lstItems)
        {
            return base.delete(lstItems);
        }

        protected override List<Adress> deleteItems(List<Adress> lstItems)
        {
            foreach (var item in (from au in ctx.Adresses
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.AdressTyp_FKID = updateItem.AdressTyp_FKID;
                item.Person_FKID = updateItem.Person_FKID;
                item.Organisation_FKID = updateItem.Organisation_FKID;
                item.AdressVariant_FKID = updateItem.AdressVariant_FKID;
                item.UpdateradDatum = DateTime.Now;
            }
            ctx.SubmitChanges();
            return lstItems;
        }
    }
}
