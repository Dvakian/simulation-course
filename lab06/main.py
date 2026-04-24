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
            text="1. Дискретная СВ",
            width=35,
            command=self.open_discrete,
        ).pack(pady=8)

        tk.Button(
            self.root,
            text="2. Нормальная СВ",
            width=35,
            command=self.open_normal,
        ).pack(pady=8)

    def open_discrete(self):
        self.root.withdraw()  # спрятали меню
        Interface(self.root)  # передаём ссылку

    def open_normal(self):
        self.root.withdraw()
        NormalInterface(self.root)

    def run(self):
        self.root.mainloop()


app = MainMenu()
app.run()
