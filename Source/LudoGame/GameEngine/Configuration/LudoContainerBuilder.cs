﻿using System;
using LudoGame.GameEngine.Classes;
using LudoGame.GameEngine.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LudoGame.GameEngine.Configuration
{
    public class LudoContainerBuilder
    {
        public IServiceProvider Build()
        {
            var container = new ServiceCollection();

            container
                .AddScoped<IBoardCollection, IBoardCollection>()
                .AddScoped<IGameAction, GameAction>()
                .AddScoped<IGamePlay, GamePlay>()
                .AddScoped<IOptionsValidator, OptionsValidator>()
                .AddSingleton<IDice, Dice>()
                .AddSingleton<IBoardOrm, BoardOrm>();

            return container.BuildServiceProvider();
        }
    }
}