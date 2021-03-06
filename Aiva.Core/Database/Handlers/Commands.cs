﻿using System;
using System.Linq;

namespace Aiva.Core.Database.Handlers {
    public class Commands {
        /// <summary>
        /// Increate the stack from the command
        /// </summary>
        /// <param name="commandName"></param>
        public void IncreaseCommandCount(string commandName) {
            using (var context = new Storage.DatabaseContext()) {
                var command = context.Commands.SingleOrDefault(c => String.Compare(commandName, c.Name, true) == 0);

                if (command != null) {
                    command.Stack++;

                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Add a command
        /// </summary>
        /// <param name="creater"></param>
        /// <param name="commandName"></param>
        /// <param name="text"></param>
        internal void AddCommand(string creater, string commandName, string text) {
            // create command object
            var command = new Storage.Commands {
                Stack = 0,
                CreatedAt = DateTime.Now,
                CreatedFrom = creater,
                Name = commandName,
                Text = text
            };

            using (var context = new Storage.DatabaseContext()) {
                // check if there is no command with the same name
                var dbCommand = context.Commands.SingleOrDefault(
                    c => string.Compare(c.Name, commandName, true) == 0);

                if (dbCommand == null) {
                    context.Commands.Add(command);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Edit a command
        /// </summary>
        /// <param name="commandName"></param>
        /// <param name="text"></param>
        internal void EditCommand(string commandName, string text) {
            using (var context = new Storage.DatabaseContext()) {
                var command = context.Commands.SingleOrDefault(
                    c => string.Compare(c.Name, commandName, true) == 0);

                if (command != null) {
                    command.Text = text;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Remove a command
        /// </summary>
        /// <param name="commandName"></param>
        internal void RemoveCommand(string commandName) {
            using (var context = new Storage.DatabaseContext()) {
                var command = context.Commands.SingleOrDefault(
                    c => string.Compare(c.Name, commandName, true) == 0);

                if (command != null) {
                    context.Commands.Remove(command);
                    context.SaveChanges();
                }
            }
        }
    }
}