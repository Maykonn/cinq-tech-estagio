class Cidade:
def __init__(self, nome, estado):
self.nome = nome
self.estado = estado

def __str__(self):
return self.nome+ "-"+self.estado

def __eq__(self, other):
"""Overrides the default implementation"""
if isinstance(other, Cidade):
return self.nome == other.nome and self.estado == other.estado
return False







class Pessoa:
def __init__(self, nome, cidade):
self.nome = nome
self.cidade = cidade
self.seguidores=[]
self.seguindo=[]

def seguir(self, pessoa):
self.seguindo.append(pessoa)
pessoa.seguidores.append(self)

def seguidoresEmComum(self, pessoa):
return [seguidor for seguidor in self.seguidores if seguidor in pessoa.seguidores]

def seguidoresDe(self, cidade):
return sorted([seguidor for seguidor in self.seguidores if seguidor.cidade == cidade], key = lambda p : p.nome)

def __str__(self):
return self.nome + " de " + str(self.cidade)








def printSeguindo(pessoa):
print(f"{pessoa} segue {', '.join(str(x) for x in pessoa.seguindo) }");
def printSeguidoresEmComum(pessoa1,pessoa2):
print(f"{pessoa1} e {pessoa2} ambos são seguidos por: {', '.join(str(x) for x in pessoa1.seguidoresEmComum(pessoa2)) }");
def printSeguidoresDe(pessoa,cidade):
print(f"{pessoa} tem os seguintes seguidores de {cidade}: {', '.join(str(x) for x in pessoa.seguidoresDe(cidade)) }");

curitiba = Cidade("Curitiba","PR")
maringa = Cidade("Maringá","PR")
rio = Cidade("Rio de Janeiro","RJ")







tiago=Pessoa("Tiago",curitiba)
marcio=Pessoa("Marcio",curitiba)
wesley=Pessoa("Wesley",maringa)
jonas=Pessoa("Jonas",rio)





tiago.seguir(wesley)
tiago.seguir(marcio)
tiago.seguir(jonas)







jonas.seguir(wesley)
jonas.seguir(marcio)
jonas.seguir(tiago)







wesley.seguir(wesley)







marcio.seguir(jonas)








printSeguindo(tiago)
printSeguindo(marcio)
printSeguindo(jonas)
printSeguindo(wesley)







printSeguidoresEmComum(wesley,marcio)







printSeguidoresDe(jonas,curitiba)
