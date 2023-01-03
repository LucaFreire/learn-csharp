
Matriz mat = new Matriz(3,3);

mat.Add(0,0,25);
mat.Add(0,1,0);
mat.Add(0,2,0);

mat.Add(1,0,0);
mat.Add(1,1,66);
mat.Add(1,2,0);

mat.Add(2,0,0);
mat.Add(2,1,0);
mat.Add(2,2,45);



Matriz mat2 = new Matriz(3,3);

mat2.Add(0,0,25);
mat2.Add(0,1,0);
mat2.Add(0,2,0);

mat2.Add(1,0,0);
mat2.Add(1,1,66);
mat2.Add(1,2,0);

mat2.Add(2,0,0);
mat2.Add(2,1,0);
mat2.Add(2,2,45);


// Console.WriteLine(mat.Identidade());
// Console.WriteLine(mat.Diagonal());
// Console.WriteLine(mat.Singular());
// Console.WriteLine(mat.Simetrica());
// Console.WriteLine(mat.Simetrica());

Console.WriteLine(mat * mat2);
