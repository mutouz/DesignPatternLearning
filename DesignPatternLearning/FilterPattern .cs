using System;
using System.Collections.Generic;
using System.Text;

namespace FilterPatterns
{
    public class FilterPattern
    {
        /// <summary>
        /// 标准类
        /// </summary>
        public class Person
        {

            private String name;
            private String gender;
            private String maritalStatus;

            public Person(String name, String gender, String maritalStatus)
            {
                this.name = name;
                this.gender = gender;
                this.maritalStatus = maritalStatus;
            }

            public String getName()
            {
                return name;
            }
            public String getGender()
            {
                return gender;
            }
            public String getMaritalStatus()
            {
                return maritalStatus;
            }
        }

        /// <summary>
        /// 标准接口 
        /// </summary>
        public interface Criteria
        {
            //符合条件的人
            public List<Person> meetCriteria(List<Person> persons);
        }
        /// <summary>
        /// 筛选符合条件的人 筛选男性
        /// </summary>
        public class CriteriaMale : Criteria
        {
            public List<Person> meetCriteria(List<Person> persons)
            {
                List<Person> malePersons = new List<Person>();
                foreach (Person person in persons)
                {
                    if (person.getGender() == "MALE")
                    {
                        malePersons.Add(person);
                    }
                }
                return malePersons;
            }
        }
        /// <summary>
        /// 筛选符合条件的人 筛选女性
        /// </summary>
        public class CriteriaFemale : Criteria
        {
            public List<Person> meetCriteria(List<Person> persons)
            {
                List<Person> femalePersons = new List<Person>();
                foreach (Person person in persons)
                {
                    if (person.getGender() == "FEMALE")
                    {
                        femalePersons.Add(person);
                    }
                }
                return femalePersons;
            }
        }
        /// <summary>
        /// 筛选符合条件的人 筛选单身
        /// </summary>
        public class CriteriaSingle : Criteria
        {
            public List<Person> meetCriteria(List<Person> persons)
            {
                List<Person> femalePersons = new List<Person>();
                foreach (Person person in persons)
                {
                    if (person.getGender() == "SINGLE")
                    {
                        femalePersons.Add(person);
                    }
                }
                return femalePersons;
            }
        }

        /// <summary>
        /// and 赛选
        /// </summary>
        public class AndCriteria : Criteria
        {
            private Criteria criteria;
            private Criteria otherCriteria;
            public AndCriteria(Criteria criteria, Criteria other)
            {
                this.criteria = criteria;
                this.otherCriteria = other;
            }
            /// <summary>
            /// 符合条件的
            /// </summary>
            /// <param name="persons"></param>
            /// <returns></returns>
            public List<Person> meetCriteria(List<Person> persons)
            {
                List<Person> firstCriteriaPersons = criteria.meetCriteria(persons);
                return otherCriteria.meetCriteria(firstCriteriaPersons);
            }
        }

        public class OrCriteria : Criteria
        {
            private Criteria criteria;
            private Criteria otherCriteria;
            public OrCriteria(Criteria criteria, Criteria otherCriteria)
            {
                this.criteria = criteria;
                this.otherCriteria = otherCriteria;
            }
            public List<Person> meetCriteria(List<Person> persons)
            {
                List<Person> firstCriteriaItems = criteria.meetCriteria(persons);
                List<Person> otherCriteriaItems = otherCriteria.meetCriteria(persons);

                foreach (Person person in otherCriteriaItems)
                {
                    if (!firstCriteriaItems.Contains(person))
                    {
                        firstCriteriaItems.Add(person);
                    }
                }
                return firstCriteriaItems;
            }
        }
        /// <summary>
        /// 这种模式允许开发人员使用不同的标准来过滤一组对象，通过逻辑运算以解耦的方式把它们连接起来。这种类型的设计模式属于结构型模式，它结合多个标准来获得单一标准。
        /// </summary>
        public class CriteriaPattrnDemo
        {
            public void Use()
            {
                List<Person> persons = new List<Person>();
                persons.Add(new Person("Robert", "Male", "Single"));
                persons.Add(new Person("John", "Male", "Married"));
                persons.Add(new Person("Laura", "Female", "Married"));
                persons.Add(new Person("Diana", "Female", "Single"));
                persons.Add(new Person("Mike", "Male", "Single"));
                persons.Add(new Person("Bobby", "Male", "Single"));
                //男性标准
                Criteria male = new CriteriaMale();
                //女性标准
                Criteria female = new CriteriaFemale();
                //单一条件 
                Criteria single = new CriteriaSingle();
                //add 条件
                Criteria singleMale = new AndCriteria(single, male);
                //or 条件
                Criteria singleOrFemale = new OrCriteria(single, female);
                //赛选条件
                porintPersons(male.meetCriteria(persons));
                porintPersons(female.meetCriteria(persons));
                porintPersons(singleMale.meetCriteria(persons));
                porintPersons(singleOrFemale.meetCriteria(persons));
            }
            //输出数据
            public static void porintPersons(List<Person> persons)
            {
                foreach (Person person in persons)
                {
                    var name = person.getName() + person.getGender() + person.getMaritalStatus();
                }
            }
        }
    }
}
