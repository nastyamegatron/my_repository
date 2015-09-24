a = [1, -1, 2, -7, 4, -8]
min = a.min
puts a.map { |el| el < 0 ? min : el}