using System;
using System.Collections.Generic;
using System.Linq;
using LPT.Interfaces;
using LPT.Models;

namespace LPT.Services
{
    public class MedidorExperimentoRepository : IGenericRepository
    {
        private LPTContext context;
        private List<MedidorExperimento> _all;
        public MedidorExperimentoRepository(LPTContext ctx)
        {
            InitializeData(ctx);
        }
        private void InitializeData(LPTContext ctx)
        {
            context = ctx;
            _all = context.MedidorExperimento.ToList();
        }
        IEnumerable<object> IGenericRepository.All
        {
            get
            {
                return _all;
            }
        }
        public object Create(object p){
            try
            {
                MedidorExperimento r = (context.MedidorExperimento.Add((MedidorExperimento)p)).Entity;
                context.SaveChanges();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Read(int idMedidorExperimento){
            try
            {
                MedidorExperimento r = (from p in context.MedidorExperimento where p.IdMedidorExperimento==idMedidorExperimento select p).FirstOrDefault<MedidorExperimento>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Update(int idMedidorExperimento,object newObject ){
            try
            {
                MedidorExperimento r = (from p in context.MedidorExperimento where p.IdMedidorExperimento==idMedidorExperimento select p).FirstOrDefault<MedidorExperimento>();
                foreach(var att in ((MedidorExperimento) newObject).GetType().GetProperties()){
                if(!att.Name.Equals("idMedidorExperimento"))r.GetType().GetProperty(att.Name).SetValue(r,att.GetValue(newObject));
                }
                context.Entry(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string Delete(int idMedidorExperimento){
            try
            {
                var r = (from p in context.MedidorExperimento where p.IdMedidorExperimento==idMedidorExperimento select p).FirstOrDefault<MedidorExperimento>();
                context.MedidorExperimento.Remove(r);
                context.SaveChanges();
                return "MedidorExperimento removido com sucesso!";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Falha ao remover MedidorExperimento!";
            }
        }
        public List<object> ReadManyByParam(string Medidor){
            try
            {
                List<object> r = (from p in context.MedidorExperimento where p.Medidor==Medidor select p).ToList<object>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<object> MedidorExperimentoAll(){
        return _all.ToList<object>();
        }
    }
}