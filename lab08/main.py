from core import PoissonFlow


def main():
    try:
        print("Моделирование пуассоновского потока заявок на сервер")
        print()

        lambda_ = float(input("Введите интенсивность потока lambda: "))
        T = float(input("Введите длину интервала наблюдения T: "))
        total_time = float(input("Введите общее время моделирования: "))

        flow = PoissonFlow(lambda_)

        results = flow.experiment(T, total_time)

        distribution = flow.get_distribution(results)
        mean = flow.get_mean(results)
        variance = flow.get_variance(results)

        print("\n=========================")
        print("Результаты моделирования")
        print(f"Интенсивность потока lambda: {lambda_}")
        print(f"Длина интервала наблюдения T: {T}")
        print(f"Общее время моделирования: {total_time}")
        print(f"Количество интервалов наблюдения: {len(results)}")

        print("\n-----------------------")
        print(f"Среднее число заявок за интервал T: {mean:.4f}")
        print(f"Дисперсия числа заявок за интервал T: {variance:.4f}")
        print("-----------------------")

        print("\n=========================")
        print("Эмпирическое распределение числа заявок:")
        for count, freq in distribution.items():
            print(f"{count} заявок: {freq:.4f}")
        print(f"Сумма частот: {sum(distribution.values()):.4f}")

    except ValueError as error:
        print()
        print("Ошибка:", error)


if __name__ == "__main__":
    main()
