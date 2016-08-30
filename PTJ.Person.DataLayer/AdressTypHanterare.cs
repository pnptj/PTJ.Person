using PTJ.Base.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.DataLayer
{
    public class AdressTypHanterare : Base<int, AdressTyp, DBPersonDataContext, int, int, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public enum Relations
        {
            Adress,
            AdressVariant,
        }

        public AdressTypHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            timeView = DateTime.Now;
            ctx = new DBPersonDataContext();
            lstResults = new List<AdressTyp>();
            result = new AdressTyp();
        }

        public List<AdressTyp> GetAll()
        {
            return base.getAll();
        }

        protected override List<AdressTyp> all()
        {
            return ctx.AdressTyps.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView) == true).OrderBy(s => s.Typ.Trim()).ToList();
        }

        public bool Exists(List<AdressTyp> lstItems)
        {
            return base.exists(lstItems);
        }

        protected override bool existsItems(List<AdressTyp> lstItems)
        {
            return (from a in ctx.AdressTyps
                    where lstItems.Select(s => s.Typ.Trim().ToLower()).Contains(a.Typ.Trim().ToLower())
                    select a).Count() > 0;
        }

        public bool Exists(List<int> lstIds)
        {
            return base.exists(lstIds);
        }

        protected override bool existsItems(List<int> lstIds)
        {
            return (from a in ctx.AdressTyps
                    where lstIds.Select(s => s).Contains(a.Id)
                    select a).Count() > 0;
        }

        public AdressTyp GetById(int id)
        {
            return base.getById(id);
        }

        protected override AdressTyp byId(int id)
        {
            return ctx.AdressTyps.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView)).Single(s => s.Id == id);
        }

        public List<AdressTyp> GetByName(string name)
        {
            return base.getBy1(name);
        }

        protected override List<AdressTyp> by1(object value)
        {
            return ctx.AdressTyps
                        .Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView))
                        .Where(w => w.Typ.Trim().ToLower().IndexOf(value.ToString().ToLower()) > -1)
                        .OrderBy(o => o.Typ.Trim().ToLower()).ToList();
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
            return (from a in ctx.AdressTyps
                    join b in ctx.Adresses on a.Id equals b.AdressTyp_FKID
                    where b.Id == id
                    select new Base.Schemas.KeyValue<AdressTyp, Adress>() { Key = a, Value = b }).Distinct().ToList();
        }

        protected override bool isRelation2(string relation)
        {
            return Relations.AdressVariant.ToString() == relation;
        }

        protected override object getRelation2(int id)
        {
            return (from a in ctx.AdressTyps
                    join b in ctx.AdressVariants on a.Id equals b.AdressTyp_FKID
                    where b.Id == id
                    select new Base.Schemas.KeyValue<AdressTyp, AdressVariant>() { Key = a, Value = b }).Distinct().ToList();
        }
        public List<AdressTyp> Add(List<AdressTyp> lstItems)
        {
            return base.add(lstItems);
        }

        protected override List<AdressTyp> addItems(List<AdressTyp> lstItems)
        {
            int newId = getNewId();
            lstItems.ForEach(f => f.Id = newId++);
            lstItems.ForEach(f => f.SkapadDatum = DateTime.Now); lstItems.ForEach(f => f.UpdateradDatum = DBDateTimeHelper.getDefaultDateTime());

            ctx.AdressTyps.InsertAllOnSubmit(lstItems);
            ctx.SubmitChanges();
            return lstItems;
        }

        private int getNewId()
        {
            int Id = 1;
            if (ctx.AdressTyps.Count() != 0)
            {
                Id = ctx.AdressTyps.Select(s => s.Id).Max() + 1;
            }
            return Id;
        }

        public List<AdressTyp> Update(List<AdressTyp> lstItems)
        {
            return base.update(lstItems);
        }

        protected override List<AdressTyp> updateItems(List<AdressTyp> lstItems)
        {
            List<AdressTyp> lstAdressTypResult = new List<AdressTyp>();
            foreach (var item in (from au in ctx.AdressTyps
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.Typ = updateItem.Typ;
                item.UpdateradDatum = DateTime.Now;
                lstAdressTypResult.AddRange(this.Add(new List<AdressTyp>() { item }));
            }
            ctx.SubmitChanges();
            return lstItems;
        }

        public List<AdressTyp> Delete(List<AdressTyp> lstItems)
        {
            return base.delete(lstItems);
        }

        protected override List<AdressTyp> deleteItems(List<AdressTyp> lstItems)
        {
            foreach (var item in (from au in ctx.AdressTyps
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.Typ = updateItem.Typ;
                item.UpdateradDatum = DateTime.Now;
            }
            ctx.SubmitChanges();
            return lstItems;
        }

        private string getFullAddress(AdressTyp adress)
        {
            return adress.Typ.Trim();
        }
    }
}
