import tkinter as tk
from tkinter import messagebox

import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg

from core import MarkovWeatherCalculate, MarkovWeatherGenerator


class WeatherApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Марковская модель погоды")

        self.names = {1: "Ясно", 2: "Облачно", 3: "Пасмурно"}

        self.colors = {1: "gold", 2: "skyblue", 3: "gray"}

        self.times = []
        self.states = []
        self.index = 0
        self.running = False

        self.create_widgets()

    def create_widgets(self):
        frame = tk.Frame(self.root)
        frame.pack(side=tk.LEFT, padx=10, pady=10, fill=tk.Y)

        tk.Label(frame, text="Матрица интенсивностей Q").pack()

        default_q = [[-0.4, 0.3, 0.1], [0.4, -0.8, 0.4], [0.1, 0.4, -0.5]]

        self.q_entries = []

        for i in range(3):
            row = []
            row_frame = tk.Frame(frame)
            row_frame.pack()

            for j in range(3):
                entry = tk.Entry(row_frame, width=8)
                entry.insert(0, str(default_q[i][j]))
                entry.pack(side=tk.LEFT)
                row.append(entry)

            self.q_entries.append(row)

        tk.Label(frame, text="Начальное состояние").pack()
        self.start_entry = tk.Entry(frame)
        self.start_entry.insert(0, "1")
        self.start_entry.pack()

        tk.Label(frame, text="Время моделирования, дней").pack()
        self.t_entry = tk.Entry(frame)
        self.t_entry.insert(0, "100")
        self.t_entry.pack()

        tk.Label(frame, text="Скорость визуализации, мс").pack()
        self.speed_entry = tk.Entry(frame)
        self.speed_entry.insert(0, "300")
        self.speed_entry.pack()

        tk.Button(frame, text="Запустить", command=self.start).pack(pady=5)
        tk.Button(frame, text="Остановить", command=self.stop).pack(pady=5)

        self.weather_label = tk.Label(
            frame, text="Погода: -", font=("Arial", 16), width=20, height=3
        )
        self.weather_label.pack(pady=10)

        self.text = tk.Text(frame, width=65, height=15)
        self.text.pack()

        self.fig, (self.ax1, self.ax2) = plt.subplots(2, 1, figsize=(8, 6))
        self.canvas = FigureCanvasTkAgg(self.fig, master=self.root)
        self.canvas.get_tk_widget().pack(side=tk.RIGHT, padx=10, pady=10)

    def read_q(self):
        Q = []

        for i in range(3):
            row = []
            for j in range(3):
                row.append(float(self.q_entries[i][j].get()))
            Q.append(row)

        return Q

    def check_q(self, Q):
        for i in range(3):
            s = sum(Q[i])

            if abs(s) > 1e-9:
                return False

            if Q[i][i] >= 0:
                return False

            for j in range(3):
                if i != j and Q[i][j] < 0:
                    return False

        return True

    def start(self):
        try:
            Q = self.read_q()
            T = float(self.t_entry.get())
            start_state = int(self.start_entry.get())

            if start_state not in [1, 2, 3]:
                raise ValueError

            if not self.check_q(Q):
                messagebox.showerror(
                    "Ошибка",
                    "Матрица Q неверна: строки должны суммироваться в 0, "
                    "диагональ отрицательная, остальные элементы неотрицательные.",
                )
                return

            generator = MarkovWeatherGenerator(Q, start_state)
            calculator = MarkovWeatherCalculate(Q)

            self.times, self.states, durations = generator.experiment(T)
            stats, emp, theor = calculator.stats_text(durations)

            self.text.delete("1.0", tk.END)
            self.text.insert(tk.END, stats)

            self.index = 0
            self.running = True
            self.animate(emp, theor)

        except Exception:
            messagebox.showerror("Ошибка", "Проверьте введенные данные.")

    def stop(self):
        self.running = False

    def animate(self, emp, theor):
        if not self.running:
            return

        if self.index >= len(self.states):
            self.running = False
            return

        current_state = self.states[self.index]
        current_time = self.times[self.index]

        self.weather_label.config(
            text=f"День {current_time:.2f}\n{self.names[current_state]}",
            bg=self.colors[current_state],
        )

        self.ax1.clear()
        self.ax2.clear()

        self.ax1.step(
            self.times[: self.index + 1], self.states[: self.index + 1], where="post"
        )
        self.ax1.set_title("Смена погоды во времени")
        self.ax1.set_xlabel("t, дни")
        self.ax1.set_ylabel("Состояние")
        self.ax1.set_yticks([1, 2, 3])
        self.ax1.set_yticklabels(["Ясно", "Облачно", "Пасмурно"])
        self.ax1.grid(True)

        x = [1, 2, 3]
        width = 0.35

        self.ax2.bar([i - width / 2 for i in x], emp, width, label="Эмпирическое")
        self.ax2.bar([i + width / 2 for i in x], theor, width, label="Теоретическое")
        self.ax2.set_title("Стационарное распределение")
        self.ax2.set_xticks(x)
        self.ax2.set_xticklabels(["Ясно", "Облачно", "Пасмурно"])
        self.ax2.set_ylim(0, 1)
        self.ax2.legend()
        self.ax2.grid(True)

        self.canvas.draw()

        self.index += 1
        speed = int(self.speed_entry.get())
        self.root.after(speed, lambda: self.animate(emp, theor))


if __name__ == "__main__":
    root = tk.Tk()
    app = WeatherApp(root)
    root.mainloop()
