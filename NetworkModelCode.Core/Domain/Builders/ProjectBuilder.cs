using NetworkModelCode.Core.Domain.Entities;

using System;
using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Builders
{
    /// <summary>
    /// Собирает проект пользователя.
    /// </summary>
    public sealed class ProjectBuilder
    {
        private Project Project { get; }

        /// <summary>
        /// Инициализирует свойства.
        /// </summary>
        public ProjectBuilder()
        {
            Project = new();
        }

        /// <summary>
        /// Присоединяет наименование.
        /// </summary>
        /// <param name="title"> Параметр наименование. </param>
        /// <returns> Данный объект проекта. </returns>
        public ProjectBuilder SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Передано пустое значение.", nameof(title));
            }

            Project.Title = title;
            return this;
        }

        /// <summary>
        /// Присоединяет количестов работ.
        /// </summary>
        /// <param name="count"> Параметр количество работ. </param>
        /// <returns> Данный объект проекта. </returns>
        public ProjectBuilder SetWorkCount(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("Переданно некорректное значение.", nameof(count));
            }

            Project.WorkCount = count;
            return this;
        }

        /// <summary>
        /// Присоединяет список технологических условий.
        /// </summary>
        /// <param name="technologicalConditions"> Параметр список технологических условий. </param>
        /// <returns> Данный объект проекта. </returns>
        public ProjectBuilder SetTechnologicalConditions(IReadOnlyList<TechnologicalCondition> technologicalConditions)
        {
            if (technologicalConditions == null)
            {
                throw new ArgumentNullException("Передана пустая ссылка.", nameof(technologicalConditions));
            }

            Project.WorkCount = technologicalConditions.Count;
            Project.TechnologicalConditions = technologicalConditions;
            return this;
        }

        /// <summary>
        /// Присоединяет список сетевых событий.
        /// </summary>
        /// <param name="events"> Параметр список сетевых событий. </param>
        /// <returns> Данный объект проекта. </returns>
        public ProjectBuilder SetNetworkEvents(IReadOnlyList<NetworkEvent> events)
        {
            if (events == null)
            {
                throw new ArgumentNullException("Передана пустая ссылка.", nameof(events));
            }

            Project.NetworkEvents = events;
            return this;
        }

        /// <summary>
        /// Присоединяет список временных характеристик.
        /// </summary>
        /// <param name="timeCharacteristics"> Параметр список временных характеристик. </param>
        /// <returns></returns>
        public ProjectBuilder SetTimeCharacteristics(IReadOnlyList<TimeCharacteristic> timeCharacteristics)
        {
            if (timeCharacteristics == null)
            {
                throw new ArgumentNullException("Передана пустая ссылка.", nameof(timeCharacteristics));
            }

            Project.TimeCharacteristics = timeCharacteristics;
            return this;
        }

        /// <summary>
        /// Возвращает собранный проект пользователя.
        /// </summary>
        /// <returns> Проект пользователя. </returns>
        public Project Build()
        {
            return Project;
        }
    }
}
