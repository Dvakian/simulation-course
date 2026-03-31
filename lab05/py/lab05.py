import random
import tkinter as tk

from lab05_GUI import AnswerApp


class Answer:
    def __init__(self, p):
        self.p = p

    def get_answer(self):
        alpha = random.random()

        if alpha < self.p:
            return "Да"
        else:
            return "Нет"


class MagicBalls:
    def __init__(self):
        self.answers = [
            "Да",
            "Нет",
            "Скорее да",
            "Скорее нет",
            "Возможно",
            "Спроси позже",
            "Определённо да",
            "Определённо нет",
            "Хз",
            "Точно ли тебе нужен ответ на этот вопрос?",
        ]
        self.prob = [0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1]

    def get_answer(self):
        A = random.random()
        k = 0
        print("начальное A = ", A)
        while k < len(self.prob):
            A = A - self.prob[k]

            print("A =", A)
            print("Ak =", self.answers[k])
            print("k =", k)

            if A <= 0:
                return self.answers[k]

            k += 1

        return self.answers[-1]


def main():
    p = 0.5
    root = tk.Tk()
    AnswerApp(root, Answer(p), MagicBalls())
    root.mainloop()


if __name__ == "__main__":
    main()
