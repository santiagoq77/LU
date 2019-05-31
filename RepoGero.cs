using System;
using PersonRepository.Entities;
using PersonRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace PersonValidator
{
    public class RepoGero : IPersonRepositoryBasic
    {
        public RepoGero(){
        }

        private bool ValidarMail(string email){
            return email.Contains('@') && email.Contains('.');
        }
        private Person Find(int id){
            return People.Find(x => x.Id == id);
        }
        private bool ValidatePerson(Person person){
            return  person.Age > 0 && ValidarMail(person.Email);
        }
        public List<Person> People { get; set; }


        /// <summary>
        /// Agrega una persona. 
        /// Validar que:
        /// <list type="bullet">
        ///     <item><description>El Id no exista en la colección.</description></item>
        ///     <item><description>La edad no sea 0 o negativa.</description></item>
        ///     <item><description>El email sea valido.</description></item>
        /// </list>
        /// </summary>
        /// <param name="person">La persona a agregar</param>
        public void Add(Person person){
            if(ValidatePerson(person) && !People.Exists(x => x.Id == person.Id)) {
                People.Add(person);
            }
        }

        /// <summary>
        /// Actualiza una persona. 
        /// Validar que:
        /// <list type="bullet">
        ///     <item><description>El Id exista en la colección.</description></item>
        ///     <item><description>La edad no sea 0 o negativa.</description></item>
        ///     <item><description>El email sea valido.</description></item>
        /// </list>
        /// </summary>
        /// <param name="person">La persona a actualizar</param>
        public void Update(Person person){
            if(ValidatePerson(person) && People.Exists(x => x.Id == person.Id)){
                Person search = Find(person.Id);
                People.Remove(search);
                People.Add(person);
            }

        }
        
        /// <summary>
        /// Borra una persona
        /// </summary>
        /// <param name="id">El id de la persona a boorar</param>
        public void Delete(int id){
            Person search = Find(id);
            People.Remove(search);
        }

        /// <summary>
        /// Filtra el resultado de las personas.
        /// </summary>
        /// <param name="name">Nombre a filtrar. Valor vacio o null anula el filtro</param>
        /// <param name="age">Edad a filtrar. Valor 0 anula el filtro</param>
        /// <param name="email">Email a filtrar. Valor vacio o null anula el filtro. Puede filtrar por partes del mail</param>
        /// <returns>El listado de personas filtrado</returns>
        public List<Person> GetFiltered(string name, int age, string email){
            List<Person> result = new List<Person>();
            Func<Person,bool> fillter_age = (p) =>p.Age == age;
            Func<Person,bool> fillter_name = (p) =>p.Name == name;
            Func<Person,bool> fillter_email = (p) =>p.Email.Contains(email);

            if(name is null || name == ""){
                fillter_name = (p) => true;
            }

            if(age == 0){
                fillter_age = (p) => true;
            }

            if(email is null || email == ""){
                fillter_email = (p) =>true;
            }

            foreach(Person p in People){
                if(fillter_name(p) && fillter_age(p) && fillter_email(p)){
                    result.Add(p);
                }
            }
            return result;

            // Esta sentencia tambien funciona, incluso requiere menos linea de codigo
            // pero es mas complicada de comprender. Para aquellos que no entiendan demasiado
            // aun de programacion es preferible que no le preste demasiado detalle por ahora.
            
            /* Func<Person,bool> filter = (p) => (fillter_name(p) && fillter_age(p) && fillter_email(p));
            return (from p in People where filter(p) select p).ToList(); */
        }

        /// <summary>
        /// Obtiene una persona 
        /// </summary>
        /// <param name="Id">Id de la persona</param>
        /// <returns>La persona que tiene el <paramref name="Id"/></returns>
        public Person GetPerson(int Id){
            return Find(Id);
        }


        /// <summary>
        /// Obtiene la cantidad de personas en el rango de edad
        /// </summary>
        /// <param name="min">Minimo de edad (inclusive)</param>
        /// <param name="max">Maximo de edad (inclusive)</param>
        /// <returns>La cantidad de personas en el rango de edad</returns>
        public int GetCountRangeAges(int min, int max){

            return (from P in People where (P.Age >= min && P.Age <= max) select P.Age).Count();
            /* int result = 0;
            foreach(Person p in People){
                if(p.Age <= max && p.Age >= min){
                    result ++;
                }
            }
            return result; */
        }
    }
}

