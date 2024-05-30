import random
import numpy as np

n = 100000000   # 試行回数
r = 0.0001       # 円の半径

count = 0
for i in range(n):
  x = random.uniform(0,r)
  y = random.uniform(0,r)

  # if (np.sqrt(x**2 + y**2) <= r):
  if ((x**2 + y**2) <= r**2):
    count += 1;

print('{:.1000f}'.format(count / n * 4))