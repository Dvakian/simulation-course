import math
import random

import matplotlib.pyplot as plt


class PoissonFlow:
    def __init__(self, lambda_):
        if lambda_ <= 0:
            raise ValueError("lambda должно быть больше 0")

        self.lambda_ = lambda_

    def generate_interval(self):
        return -math.log(random.random()) / self.lambda_  # -ln(alpa)/lambda

    def simulate(self, T):
        if T <= 0:
            raise ValueError("T должно быть больше 0")

        t = 0
        count = 0

        while t < T:
            t += self.generate_interval()

            if t <= T:
                count += 1

        return count

    def experiment(self, T, total_time):
        if total_time <= 0:
            raise ValueError("total_time должно быть больше 0")

        results = []
        ex_count = int(total_time / T)

        if ex_count <= 0:
            raise ValueError("Общее время моделирования должно быть больше 0")

        for _ in range(ex_count):
            count = self.simulate(T)
            results.append(count)
        return results

    def get_mean(self, results):
        return sum(results) / len(results)

    def get_variance(self, results):
        mean = self.get_mean(results)
        return sum((x - mean) ** 2 for x in results) / len(results)

    def get_distribution(self, results):
        distribution = {}

        for x in results:
            if x not in distribution:
                distribution[x] = 0
            distribution[x] += 1

        for x in distribution:
            distribution[x] /= len(results)

        return dict(sorted(distribution.items()))

    def simulate_debug(self, T):
        if T <= 0:
            raise ValueError("T должно быть больше 0")

        t = 0
        count = 0
        intervals = []

        while t < T:
            tau = self.generate_interval()
            t += tau

            accepted = t <= T

            if accepted:
                count += 1

            intervals.append({"tau": tau, "t": t, "accepted": accepted, "count": count})

        return count, intervals
