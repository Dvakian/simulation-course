import tkinter as tk


class AnswerApp:
    def __init__(self, root, yesno_model, magic_model):
        self.yesno_model = yesno_model
        self.magic_model = magic_model

        root.title("Предсказатель")
        root.geometry("400x260")

        self.label = tk.Label(root, text="Введите вопрос:", font=("Arial", 12))
        self.label.pack(pady=5)

        self.entry = tk.Entry(root, width=35, font=("Arial", 12))
        self.entry.pack(pady=5)

        self.button_yesno = tk.Button(
            root, text="Да / Нет", command=self.on_yesno_click, font=("Arial", 12)
        )
        self.button_yesno.pack(pady=5)

        self.button_magic = tk.Button(
            root, text="Magic Ball", command=self.on_magic_click, font=("Arial", 12)
        )
        self.button_magic.pack(pady=5)

        self.result_label = tk.Label(root, text="", font=("Arial", 18))
        self.result_label.pack(pady=15)

    def on_yesno_click(self):
        question = self.entry.get()

        if question == "":
            self.result_label.config(text="Введите запрос")
            return

        answer = self.yesno_model.get_answer()

        self.result_label.config(text=answer)

    def on_magic_click(self):
        question = self.entry.get()

        if question == "":
            self.result_label.config(text="Введите запрос")
            return

        answer = self.magic_model.get_answer()

        self.result_label.config(text=answer)
