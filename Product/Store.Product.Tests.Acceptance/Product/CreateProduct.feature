Feature: Create Product
	This case used to create product

@Product
Scenario: Create Product with properties

	Given That the product was create with data

	| Code   | Name              |
	| 1A2B3C | Samsung Galaxy S8 |

	And The product have this properties

	| Name            | Value |
	| Memória Ram     | 6Gb   |
	| Memória Interna | 64Gb  |
	| Tamanho da Tela | 5.8"  |

	When I save the product in database

	Then the result should be a object created

	| Code   | Name              | IsDeleted |
	| 1A2B3C | Samsung Galaxy S8 | false     |

	And the properties of product is

	| Name            | Value |
	| Memória Ram     | 6Gb   |
	| Memória Interna | 64Gb  |
	| Tamanho da Tela | 5.8"  |

@Product
Scenario: Create Product without properties

	Given That the product was create with data

	| Code   | Name              |
	| 1A2B3C | Samsung Galaxy S8 |

	When I save the product in database

	Then the result should be a object created

	| Code   | Name              | IsDeleted |
	| 1A2B3C | Samsung Galaxy S8 | false     |