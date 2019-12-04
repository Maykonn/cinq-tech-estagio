<?php

class Cidade
{
	public $nome = '';
	public $estado = '';

	public function __construct($nome, $estado)
	{
		$this->nome = $nome;
		$this->estado = $estado;
	}
}

class Pessoa
{
	public $nome = '';
	public $cidade;
	public $seguidores = [];
	public $seguindo = [];

	public function __construct($nome, $cidade)
	{
		$this->nome = $nome;
		$this->cidade = $cidade;
	}

	public function seguir($pessoa)
	{
		$this->seguindo[] = $pessoa;
		$pessoa->seguidores[] = $this;
	}

	public function seguidoresEmComum($pessoa)
	{
		$seguidoresEmComum = array();
		foreach ($this->seguidores as $meuSeguidor) {
			foreach ($pessoa->seguidores as $seguidorDele) {
				if ($meuSeguidor->nome == $seguidorDele->nome) {
					$seguidoresEmComum[] = $seguidorDele;
				}
			}
		}
		return $seguidoresEmComum;
	}

	public function seguidoresDe($cidade)
	{
		$seguidores = [];
		foreach ($this->seguidores as $pessoa) {
			if ($pessoa->cidade->nome == $cidade->nome) {
				$seguidores[] = $pessoa;
			}
		}
		return $seguidores;
	}
}

$c1 = new Cidade('Curitiba', 'PR');
$c2 = new Cidade('Maringá', 'PR');
$c3 = new Cidade('Rio de Janeiro', 'SP');

$p1 = new Pessoa('Marcio', $c1);
$p2 = new Pessoa('Tiago', $c1);
$p3 = new Pessoa('Wesley', $c2);
$p4 = new Pessoa('Jonas', $c3);

$p2->seguir($p1);
$p2->seguir($p3);
$p2->seguir($p4);

$p4->seguir($p1);
$p4->seguir($p2);
$p4->seguir($p3);

$p1->seguir($p3);
$p3->seguir($p4);

echo "2.1) Mostre no console todas as pessoas que cada pessoa está seguindo:\n";
echo $p1->nome.' de '.$p1->cidade->nome.'-'.$p1->cidade->estado." segue:\n";
echo "-> ";
foreach ($p1->seguindo as $pessoa) {
	echo $pessoa->nome.' de '.$pessoa->cidade->nome.'-'.$pessoa->cidade->estado.', ';
}

echo "\n\n";
echo $p2->nome.' de '.$p2->cidade->nome.'-'.$p2->cidade->estado." segue:\n";
echo "-> ";
foreach ($p2->seguindo as $pessoa) {
	echo $pessoa->nome.' de '.$pessoa->cidade->nome.'-'.$pessoa->cidade->estado.', ';
}

echo "\n\n";
echo $p3->nome.' de '.$p3->cidade->nome.'-'.$p3->cidade->estado." segue:\n";
echo "-> ";
foreach ($p3->seguindo as $pessoa) {
	echo $pessoa->nome.' de '.$pessoa->cidade->nome.'-'.$pessoa->cidade->estado.', ';
}

echo "\n\n";
echo $p4->nome.' de '.$p4->cidade->nome.'-'.$p4->cidade->estado." segue:\n";
echo "-> ";
foreach ($p4->seguindo as $pessoa) {
	echo $pessoa->nome.' de '.$pessoa->cidade->nome.'-'.$pessoa->cidade->estado.', ';
}

$seguidoresEmComum = $p3->seguidoresEmComum($p1);
echo "\n\n";
echo "3.1) Mostre no console os seguidores em comum entre Wesley e Marcio:\n";
echo "-> ";
foreach ($seguidoresEmComum as $pessoa) {
	echo $pessoa->nome.' de '.$pessoa->cidade->nome.'-'.$pessoa->cidade->estado.', ';
}

echo "\n\n";
echo "4.1) Mostre no Console os seguidores de Curitiba do Wesley.\n";
echo "-> ";
$seguidoresDeCuritiba = $p3->seguidoresDe($c1);
asort($seguidoresDeCuritiba);
foreach ($seguidoresDeCuritiba as $pessoa) {
	echo $pessoa->nome.' de '.$pessoa->cidade->nome.'-'.$pessoa->cidade->estado.', ';
}

echo "\n\n";