﻿namespace Tempo.Common.Setup.Repository
{
    public  interface IEntity<T> 
    {
        public  T Id { get; set; }
    }
}
