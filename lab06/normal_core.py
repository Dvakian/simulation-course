import math
import random

from scipy.stats import chi2


class NormalGenerator:
    def __init__(self, mean, var):
        self.mean = mean
        self.var = var

    def generate_standart_sum(self):
        z = 0

        for _ in range(12):
            z += random.random()

        return z - 6

    def generate(self):

        z = self.generate_standart_sum()
        return self.mean + math.sqrt(self.var) * z

    def experiment(self, N):
        emp = []

        for _ in range(N):
            emp.append(self.generate())

        return emp


class NormalCalculate:
    def __init__(self, sample, mean, var):
        self.sample = sample
        self.mean = mean
        self.var = var
        self.N = len(sample)

    def empirical_mean(self):
        s = 0

        for x in self.sample:
            s += x

        return s / self.N

    def empirical_var(self, emp_mean):
        s = 0

        for x in self.sample:
            s += x * x

        return s / self.N - emp_mean**2

    def normal_cdf(self, x):
        sigma = math.sqrt(self.var)
        z = (x - self.mean) / (sigma * math.sqrt(2))
        return 0.5 * (1 + math.erf(z))

    def theoretical_probs(self, intervals):
        probs = []

        for left, right in intervals:
            p = self.normal_cdf(right) - self.normal_cdf(left)
            probs.append(p)

        return probs

    def chi_square(self, counts, probs):
        chi = 0

        for i in range(len(counts)):
            expected = self.N * probs[i]

            if expected > 0:
                chi += (counts[i] - expected) ** 2 / expected

        return chi

    def check_chi(self, chi, k):
        df = k - 1
        chi_crit = chi2.ppf(0.95, df)

        if chi > chi_crit:
            return "Гипотеза отклоняется", chi_crit
        else:
            return "Гипотеза принимается", chi_crit

    def relative_error(self, theor, emp):
        if theor == 0:
            return 0
        return abs(emp - theor) / abs(theor)

    def auto_bins(self):
        return int(1 + math.log2(self.N))

    def histogram(self, k):
        min_val = min(self.sample)
        max_val = max(self.sample)

        h = (max_val - min_val) / k

        intervals = []
        counts = [0] * k

        for i in range(k):
            left = min_val + i * h
            right = left + h
            intervals.append((left, right))

        for x in self.sample:
            for i in range(k):
                left, right = intervals[i]

                if i == k - 1:
                    if left <= x <= right:
                        counts[i] += 1
                else:
                    if left <= x < right:
                        counts[i] += 1

        freq = []
        for c in counts:
            freq.append(c / self.N)

        return intervals, counts, freq
