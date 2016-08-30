using PTJ.Base.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.DataLayer
{
    public class AdressVariantHanterare : Base<int, AdressVariant, DBPersonDataContext, int, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public enum Relations
        {
            Adress,
            AdressTyp,
        }

        public AdressVariantHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            timeView = DateTime.Now;
            ctx = new DBPersonDataContext();
            lstResults = new List<AdressVariant>();
            result = new AdressVariant();
        }

        public List<AdressVariant> GetAll()
        {
            return base.getAll();
        }

        protected override List<AdressVariant> all()
        {
            return ctx.AdressVariants.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView) == true).OrderBy(s => s.Variant.Trim()).ToList();
        }

        public bool Exists(List<AdressVariant> lstItems)
        {
            return base.exists(lstItems);
        }

        protected override bool existsItems(List<AdressVariant> lstItems)
        {
            return (from a in ctx.AdressVariants
                    where lstItems.Select(s => s.Variant.Trim().ToLower()).Contains(a.Variant.Trim().ToLower())
                    select a).Count() > 0;
        }

        public bool Exists(List<int> lstIds)
        {
            return base.exists(lstIds);
        }

        protected override bool existsItems(List<int> lstIds)
        {
            return (from a in ctx.AdressVariants
                    where lstIds.Select(s => s).Contains(a.Id)
                    select a).Count() > 0;
        }

        public AdressVariant GetById(int id)
        {
            return base.getById(id);
        }

        protected override AdressVariant byId(int id)
        {
            return ctx.AdressVariants.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView)).Single(s => s.Id == id);
        }

        public List<AdressVariant> GetByName(string name)
        {
            return base.getBy1(name);
        }

        protected override List<AdressVariant> by1(object value)
        {
            return ctx.AdressVariants
                        .Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView))
                        .Where(w => w.Variant.Trim().ToLower().IndexOf(value.ToString().ToLower()) > -1)
                        .OrderBy(o => o.Variant.Trim().ToLower()).ToList();
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
            return (from a in ctx.AdressVariants
                    join b in ctx.Adresses on a.Id equals b.AdressVariant_FKID
                    where b.Id == id
                    select new Base.Schemas.KeyValue<AdressVariant, Adress>() { Key = a, Value = b }).Distinct().ToList();
        }

        protected override bool isRelation2(string relation)
        {
            return Relations.AdressTyp.ToString() == relation;
        }

        protected override object getRelation2(int id)
        {
            return (from a in ctx.AdressVariants
                    join b in ctx.AdressTyps on a.AdressTyp_FKID equals b.Id
                    where b.Id == id
                    select new Base.Schemas.KeyValue<AdressVariant, AdressTyp>() { Key = a, Value = b }).Distinct().ToList();
        }

        public List<AdressVariant> Add(List<AdressVariant> lstItems)
        {
            return base.add(lstItems);
        }

        protected override List<AdressVariant> addItems(List<AdressVariant> lstItems)
        {
            int newId = getNewId();
            lstItems.ForEach(f => f.Id = newId++);
            lstItems.ForEach(f => f.SkapadDatum = DateTime.Now); lstItems.ForEach(f => f.UpdateradDatum = DBDateTimeHelper.getDefaultDateTime());

            ctx.AdressVariants.InsertAllOnSubmit(lstItems);
            ctx.SubmitChanges();
            return lstItems;
        }

        private int getNewId()
        {
            int Id = 1;
            if (ctx.AdressVariants.Count() != 0)
            {
                Id = ctx.AdressVariants.Select(s => s.Id).Max() + 1;
            }
            return Id;
        }

        public List<AdressVariant> Update(List<AdressVariant> lstItems)
        {
            return base.update(lstItems);
        }

        protected override List<AdressVariant> updateItems(List<AdressVariant> lstItems)
        {
            List<AdressVariant> lstAdressVariantResult = new List<AdressVariant>();
            foreach (var item in (from au in ctx.AdressVariants
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.AdressTyp_FKID = updateItem.AdressTyp_FKID;
                item.Variant = updateItem.Variant;

                item.UpdateradDatum = DateTime.Now;
                lstAdressVariantResult.AddRange(this.Add(new List<AdressVariant>() { item }));
            }
            ctx.SubmitChanges();
            return lstItems;
        }

        public List<AdressVariant> Delete(List<AdressVariant> lstItems)
        {
            return base.delete(lstItems);
        }

        protected override List<AdressVariant> deleteItems(List<AdressVariant> lstItems)
        {
            foreach (var item in (from au in ctx.AdressVariants
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.AdressTyp_FKID = updateItem.AdressTyp_FKID;
                item.Variant = updateItem.Variant;
                item.UpdateradDatum = DateTime.Now;
            }
            ctx.SubmitChanges();
            return lstItems;
        }
    }
}
