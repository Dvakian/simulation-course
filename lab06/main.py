import tkinter as tk

from gui import Interface
from normal_gui import NormalInterface


class MainMenu:
    def __init__(self):
        self.root = tk.Tk()
        self.root.title("Лабораторная 6")
        self.root.geometry("420x230")
        self.root.configure(bg="#9fd3f5")

        tk.Label(
            self.root,
            text="Выберите часть лабораторной",
            font=("Arial", 16, "bold"),
            bg="#9fd3f5",
        ).pack(pady=25)

        tk.Button(
            self.root,
            text="1. Дискретная случайная величина",
            width=35,
            command=self.open_discrete,
        ).pack(pady=8)

        tk.Button(
            self.root,
            text="2. Нормальная случайная величина",
            width=35,
            command=self.open_normal,
        ).pack(pady=8)

    def open_discrete(self):
        self.root.destroy()
        app = Interface()
        app.run()

    def open_normal(self):
        self.root.destroy()
        app = NormalInterface()
        app.run()

    def run(self):
        self.root.mainloop()


app = MainMenu()
app.run()
