using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GenerateObjects
{
    public class Generator
    {

        private Thread _startSurvey;

        private readonly List<IGenObject> _listObjects;

        public Generator()
        {
            _listObjects = new List<IGenObject>();
        }

        public void StartGenerateSurvey(int ms)
        {
            if (ms <= 0)
            {
                ms = 1;
            } 
            if (_startSurvey == null || !_startSurvey.IsAlive)
            {
                _startSurvey = new Thread(GenerateSurvey);
                _startSurvey.Start(ms);
            }
            
            
        }

        private void GenerateSurvey(object ms)
        {

            int sumAll = 0, sumFirst = 0, sumSecond = 0, sumThird = 0;
            var rnd = new Random();
            try
            {
                for (int i = 0; ; i++)
                {

                    _listObjects.Add(new GenObject(rnd.Next(1, 4), rnd.NextDouble() * 10 + 10.0));

                    sumAll++;
                    switch (_listObjects[i].GetTypeObject())
                    {
                        case 1: sumFirst++; break;
                        case 2: sumSecond++; break;
                        case 3: sumThird++; break;
                    }

                    var sumLastTen = _listObjects.Skip(_listObjects.Count - 10).Take(10).Sum(value => value.GetDValue());

                    Console.WriteLine("Сумма объектов первого типа = {0}", sumFirst);
                    Console.WriteLine("Сумма объектов вторго типа = {0}", sumSecond);
                    Console.WriteLine("Сумма объектов третьего типа = {0}", sumThird);
                    Console.WriteLine("Сумма всех объектов = {0}", sumAll);
                    Console.WriteLine("Сумма последних 10 значений объектов = {0}", sumLastTen);

                    Thread.Sleep((int)ms);
                    Console.Clear();

                }
            }
            catch (ThreadAbortException)
            {

                Console.WriteLine("Генерация объектов завершена");
            }
            

            
            

            }

        public void AbortSurvey()
        {
            _startSurvey.Abort();
        }

        public void TimeOutSurvey(int ms)
        {
            if (ms <= 0)
            {
                ms = 1;
            }
            Thread.Sleep(ms);
        }

            
            
        }
    }

