import tkinter as tk
from tkinter import messagebox

from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
from matplotlib.figure import Figure

from discrete_core import Calculate, DiscreteGenerator


class Interface:
    def __init__(self):
        self.root = tk.Tk()
        self.root.title("Лабораторная 6")
        self.root.geometry("1100x700")
        self.root.configure(bg="#9fd3f5")

        self.results = []

        self.create_widgets()

    def create_widgets(self):
        tk.Label(
            self.root,
            text="Введите вероятности (p1...p5)",
            font=("Arial", 14, "bold"),
            bg="#9fd3f5",
        ).pack(pady=10)

        frame = tk.Frame(self.root, bg="#9fd3f5")
        frame.pack()

        self.entries = []
        defaults = ["0.264", "0.128", "0.228", "0.207", "0.173"]

        for i in range(5):
            e = tk.Entry(frame, width=10)
            e.grid(row=0, column=i, padx=5)
            e.insert(0, defaults[i])
            self.entries.append(e)

        tk.Button(
            self.root, text="Запустить", command=self.run_experiment, width=20
        ).pack(pady=10)

        self.buttons_frame = tk.Frame(self.root, bg="#9fd3f5")
        self.buttons_frame.pack()

        self.main_frame = tk.Frame(self.root, bg="#9fd3f5")
        self.main_frame.pack(pady=15)

        self.chart_frame = tk.Frame(self.main_frame, bg="white", bd=2, relief="solid")
        self.chart_frame.grid(row=0, column=0, padx=10)

        self.text_frame = tk.Frame(self.main_frame, bg="white", bd=2, relief="solid")
        self.text_frame.grid(row=0, column=1, padx=10, sticky="n")

        self.details_text = tk.Text(
            self.text_frame, width=42, height=24, font=("Arial", 10)
        )
        self.details_text.pack(padx=5, pady=5)

        self.info_label = tk.Label(
            self.root, text="", font=("Arial", 14), justify="left", bg="#9fd3f5"
        )
        self.info_label.pack(pady=10)

    def run_experiment(self):
        try:
            values = [1, 2, 3, 4, 5]
            prob = [float(e.get()) for e in self.entries]

            for p in prob:
                if p < 0:
                    messagebox.showerror(
                        "Ошибка", "Вероятности не могут быть отрицательными"
                    )
                    return

            if sum(prob) == 0:
                messagebox.showerror("Ошибка", "Сумма вероятностей должна быть > 0")
                return

            dsv = DiscreteGenerator(values, prob)
            dsv.normalize()

            self.results = []

            for N in [10, 100, 1000, 10000]:
                counts = dsv.experiment(N)

                calc_theor = Calculate(counts, N, values, dsv.prob)
                p_emp = calc_theor.empirical_prob()

                calc_emp = Calculate(counts, N, values, p_emp)

                M_theor = calc_theor.mean()
                D_theor = calc_theor.var(M_theor)

                M_emp = calc_emp.mean()
                D_emp = calc_emp.var(M_emp)

                M_error = calc_theor.relative_error(M_theor, M_emp)
                D_error = calc_theor.relative_error(D_theor, D_emp)

                chi = calc_theor.chi_kvadrat()
                chi_result = calc_theor.check_chi(chi)

                self.results.append(
                    {
                        "N": N,
                        "values": values,
                        "counts": counts,
                        "p_emp": p_emp,
                        "M": M_theor,
                        "M_emp": M_emp,
                        "D": D_theor,
                        "D_emp": D_emp,
                        "M_error": M_error,
                        "D_error": D_error,
                        "chi": chi,
                        "chi_result": chi_result,
                    }
                )
            self.create_buttons()
            self.show_result(0)

        except ValueError:
            messagebox.showerror("Ошибка", "Введите корректные числа")

    def create_buttons(self):
        for widget in self.buttons_frame.winfo_children():
            widget.destroy()

        for i, res in enumerate(self.results):
            tk.Button(
                self.buttons_frame,
                text=f"N = {res['N']}",
                command=lambda idx=i: self.show_result(idx),
                width=10,
            ).grid(row=0, column=i, padx=5)

    def show_result(self, index):
        res = self.results[index]

        for widget in self.chart_frame.winfo_children():
            widget.destroy()

        fig = Figure(figsize=(6.2, 3.5), dpi=100)
        ax = fig.add_subplot(111)

        x = res["values"]
        p = res["p_emp"]

        ax.bar(x, p, edgecolor="black")
        ax.set_title("freq.")
        ax.set_xticks(x)

        for i in range(len(x)):
            ax.text(x[i], p[i] + 0.01, f"{p[i]:.3f}", ha="center")

        canvas = FigureCanvasTkAgg(fig, master=self.chart_frame)
        canvas.draw()
        canvas.get_tk_widget().pack()

        self.details_text.delete("1.0", tk.END)

        self.details_text.insert(tk.END, f"N = {res['N']}\n\n")
        self.details_text.insert(tk.END, f"Частоты:\n{res['counts']}\n\n")
        self.details_text.insert(
            tk.END,
            f"Эмпирические вероятности:\n{[round(p, 4) for p in res['p_emp']]}\n\n",
        )

        self.details_text.insert(tk.END, f"Теоретическое среднее: {res['M']:.4f}\n")
        self.details_text.insert(tk.END, f"Выборочное среднее: {res['M_emp']:.4f}\n")
        self.details_text.insert(
            tk.END, f"Погрешность среднего: {res['M_error']:.4%}\n\n"
        )

        self.details_text.insert(tk.END, f"Теоретическая дисперсия: {res['D']:.4f}\n")
        self.details_text.insert(tk.END, f"Выборочная дисперсия: {res['D_emp']:.4f}\n")
        self.details_text.insert(
            tk.END, f"Погрешность дисперсии: {res['D_error']:.4%}\n\n"
        )

        self.details_text.insert(tk.END, f"χ² = {res['chi']:.4f}\n")
        self.details_text.insert(tk.END, "χ² критическое = 9.488\n")
        self.details_text.insert(tk.END, f"{res['chi_result']}\n")

    def run(self):
        self.root.mainloop()
