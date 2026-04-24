import random


class DiscreteGenerator:
    def __init__(self, val, prob):
        self.prob = prob
        self.val = val

    def normalize(self):
        total_sum = sum(self.prob)

        if total_sum <= 0:
            return

        for i in range(len(self.prob)):
            self.prob[i] = self.prob[i] / total_sum

    def generate(self):
        A = random.random()
        k = 0

        while k < len(self.prob):
            A -= self.prob[k]

            if A <= 0:
                return self.val[k]

            k += 1

        return self.val[-1]

    def experiment(self, N):
        counts = [0] * len(self.val)

        for _ in range(N):
            x = self.generate()
            counts[self.val.index(x)] += 1
        return counts


class Calculate:
    def __init__(self, counts, N, val, prob):
        self.counts = counts
        self.N = N
        self.val = val
        self.prob = prob

    def empirical_prob(self):
        p_emp = []

        for i in range(len(self.counts)):
            p_emp.append(self.counts[i] / self.N)

        return p_emp

    def mean(self):
        s = 0

        for i in range(len(self.val)):
            s += self.val[i] * self.prob[i]

        return s

    def var(self, mean):
        s = 0

        for i in range(len(self.val)):
            s += self.val[i] * self.val[i] * self.prob[i]

        s = s - mean * mean

        return s

    def relative_error(self, theor, emp):
        if theor == 0:
            return 0
        return abs(emp - theor) / abs(theor)

    def chi_kvadrat(self):
        chi = 0

        for i in range(len(self.counts)):
            chi += (self.counts[i] * self.counts[i]) / (self.N * self.prob[i])

        chi = chi - self.N

        return chi

    def check_chi(self, chi):
        chi_crit = 9.488

        if chi > chi_crit:
            return "Гипотеза отклоняется"
        else:
            return "Гипотеза принимается"
