using System;
using System.Collections.Generic;
using System.Linq;
using LPT.Interfaces;
using LPT.Models;

namespace LPT.Services
{
    public class DadoColetadoRepository : IGenericRepository
    {
        private LPTContext context;
        private List<DadoColetado> _all;
        public DadoColetadoRepository(LPTContext ctx)
        {
            InitializeData(ctx);
        }
        private void InitializeData(LPTContext ctx)
        {
            context = ctx;
            _all = context.DadoColetado.ToList();
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
                DadoColetado r = (context.DadoColetado.Add((DadoColetado)p)).Entity;
                context.SaveChanges();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Read(int idDadoColetado){
            try
            {
                DadoColetado r = (from p in context.DadoColetado where p.IdDadoColetado==idDadoColetado select p).FirstOrDefault<DadoColetado>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Update(int idDadoColetado,object newObject ){
            try
            {
                DadoColetado r = (from p in context.DadoColetado where p.IdDadoColetado==idDadoColetado select p).FirstOrDefault<DadoColetado>();
                foreach(var att in ((DadoColetado) newObject).GetType().GetProperties()){
                if(!att.Name.Equals("idDadoColetado"))r.GetType().GetProperty(att.Name).SetValue(r,att.GetValue(newObject));
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
        public string Delete(int idDadoColetado){
            try
            {
                var r = (from p in context.DadoColetado where p.IdDadoColetado==idDadoColetado select p).FirstOrDefault<DadoColetado>();
                context.DadoColetado.Remove(r);
                context.SaveChanges();
                return "DadoColetado removido com sucesso!";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Falha ao remover DadoColetado!";
            }
        }
        public List<object> ReadManyByParam(int Experimento){
            try
            {
                List<object> r = (from p in context.DadoColetado where p.Experimento==Experimento select p).ToList<object>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<object> DadoColetadoAll(){
        return _all.ToList<object>();
        }
    }
}