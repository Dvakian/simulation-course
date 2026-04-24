import tkinter as tk
from tkinter import messagebox

from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
from matplotlib.figure import Figure

from normal_core import NormalCalculate, NormalGenerator


class NormalInterface:
    def __init__(self):
        self.root = tk.Tk()
        self.root.title("Лабораторная 6 — Нормальная СВ")
        self.root.geometry("1000x600")
        self.root.configure(bg="#9fd3f5")

        self.create_widgets()

    def create_widgets(self):
        title = tk.Label(
            self.root,
            text="Моделирование нормальной случайной величины",
            font=("Arial", 16, "bold"),
            bg="#9fd3f5",
        )
        title.pack(pady=15)

        main_frame = tk.Frame(self.root, bg="#9fd3f5")
        main_frame.pack(pady=20)

        input_frame = tk.Frame(main_frame, bg="#9fd3f5", bd=2, relief="solid")
        input_frame.grid(row=0, column=0, padx=20, sticky="n")

        tk.Label(input_frame, text="Mean", bg="#9fd3f5", font=("Arial", 13)).grid(
            row=0, column=0, padx=15, pady=12
        )
        self.mean_entry = tk.Entry(input_frame, width=10)
        self.mean_entry.grid(row=0, column=1, padx=15, pady=12)
        self.mean_entry.insert(0, "0")

        tk.Label(input_frame, text="Variance", bg="#9fd3f5", font=("Arial", 13)).grid(
            row=1, column=0, padx=15, pady=12
        )
        self.var_entry = tk.Entry(input_frame, width=10)
        self.var_entry.grid(row=1, column=1, padx=15, pady=12)
        self.var_entry.insert(0, "1")

        tk.Label(
            input_frame, text="Sample size", bg="#9fd3f5", font=("Arial", 13)
        ).grid(row=2, column=0, padx=15, pady=12)
        self.n_entry = tk.Entry(input_frame, width=10)
        self.n_entry.grid(row=2, column=1, padx=15, pady=12)
        self.n_entry.insert(0, "1000")

        start_btn = tk.Button(
            input_frame,
            text="Start",
            command=self.run_experiment,
            width=12,
            font=("Arial", 12),
        )
        start_btn.grid(row=3, column=0, columnspan=2, pady=15)

        result_frame = tk.Frame(main_frame, bg="#9fd3f5", bd=2, relief="solid")
        result_frame.grid(row=0, column=1, padx=20)

        self.chart_frame = tk.Frame(result_frame, bg="white", bd=1, relief="solid")
        self.chart_frame.pack(padx=20, pady=15)

        self.info_label = tk.Label(
            result_frame, text="", font=("Arial", 14), justify="left", bg="#9fd3f5"
        )
        self.info_label.pack(padx=20, pady=10, anchor="w")

        buttons_frame = tk.Frame(self.root, bg="#9fd3f5")
        buttons_frame.pack(pady=5)

        for N in [10, 100, 1000, 10000]:
            tk.Button(
                buttons_frame,
                text=f"N = {N}",
                width=10,
                command=lambda n=N: self.set_n_and_run(n),
            ).grid(row=0, column=[10, 100, 1000, 10000].index(N), padx=5)

    def set_n_and_run(self, N):
        self.n_entry.delete(0, tk.END)
        self.n_entry.insert(0, str(N))
        self.run_experiment()

    def run_experiment(self):
        try:
            mean = float(self.mean_entry.get())
            var = float(self.var_entry.get())
            N = int(self.n_entry.get())

            if var <= 0:
                messagebox.showerror("Ошибка", "Дисперсия должна быть больше 0")
                return

            if N <= 0:
                messagebox.showerror("Ошибка", "Размер выборки должен быть больше 0")
                return

            if N > 1000000:
                messagebox.showerror("Ошибка", "Многа слишком")
                return

            generator = NormalGenerator(mean, var)
            sample = generator.experiment(N)

            calc = NormalCalculate(sample, mean, var)

            emp_mean = calc.empirical_mean()
            emp_var = calc.empirical_var(emp_mean)

            mean_error = calc.relative_error(mean, emp_mean)
            var_error = calc.relative_error(var, emp_var)

            k = calc.auto_bins()

            intervals, counts, freq = calc.histogram(k)
            probs = calc.theoretical_probs(intervals)

            chi = calc.chi_square(counts, probs)
            chi_result = calc.check_chi(chi)

            self.show_result(
                intervals,
                freq,
                probs,
                emp_mean,
                emp_var,
                mean_error,
                var_error,
                chi,
                chi_result,
            )

        except ValueError:
            messagebox.showerror("Ошибка", "Введите корректные числа")

    def show_result(
        self,
        intervals,
        freq,
        probs,
        emp_mean,
        emp_var,
        mean_error,
        var_error,
        chi,
        chi_result,
    ):
        for widget in self.chart_frame.winfo_children():
            widget.destroy()

        fig = Figure(figsize=(5.2, 2.7), dpi=100)
        ax = fig.add_subplot(111)

        centers = []
        labels = []

        for left, right in intervals:
            centers.append((left + right) / 2)
            labels.append(f"({left:.1f}; {right:.1f}]")

        width = intervals[0][1] - intervals[0][0]

        ax.bar(centers, freq, width=width * 0.9, edgecolor="red", alpha=0.45)

        ax.plot(centers, probs, linewidth=2)

        ax.set_xticks(centers)
        ax.set_xticklabels(labels, rotation=15, fontsize=6)
        ax.set_ylim(0, max(max(freq), max(probs)) + 0.05)

        canvas = FigureCanvasTkAgg(fig, master=self.chart_frame)
        canvas.draw()
        canvas.get_tk_widget().pack()

        is_true = chi > 11.07

        self.info_label.config(
            text=(
                f"Average: {emp_mean:.3f} (error = {mean_error:.0%})\n"
                f"Variance: {emp_var:.3f} (error = {var_error:.0%})\n\n"
                f"Chi-squared: {chi:.2f} > 11.07 is {str(is_true).lower()}\n"
                f"{chi_result}"
            )
        )

    def run(self):
        self.root.mainloop()
