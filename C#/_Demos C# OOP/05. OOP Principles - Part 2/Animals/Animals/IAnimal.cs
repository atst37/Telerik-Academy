﻿namespace Animals.Animals
{
    public interface IAnimal
    {
        string Name { get; }

        int Age { get; }

        string Speak();
    }
}