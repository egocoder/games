# configurações iniciais do jogo
import pygame
import random

pygame.init()
pygame.display.set_caption("Snake Game")
largura, altura = 1280, 720
tela = pygame.display.set_mode((largura, altura))
relogio = pygame.time.Clock()

# cores RGB
preto = (0, 0, 0)
branco = (255, 255, 255)
vermelho = (255, 0, 0)
verde = (0, 255, 0)
cinza_m = (128, 128, 128)

def gerar_comida():
    comida_x = round(random.randrange(0, largura  - tamanho_quad) / 20) * 20
    comida_y = round(random.randrange(0, altura - tamanho_quad) / 20) * 20
    return comida_x, comida_y

# parametros do snake
tamanho_quad = 20
game_speed = 16

def desenha_comida(tamanho, comida_x, comida_y):
    pygame.draw.rect(tela, verde, [comida_x, comida_y, tamanho, tamanho])

def desenhar_snake(tamanho, pixels):
    for pixel in pixels:
        pygame.draw.rect(tela, branco, [pixel[0], pixel[1], tamanho, tamanho])    

def desenhar_pontuacao(pontuacao):
    fonte = pygame.font.SysFont("Monocraft", 25)
    texto = fonte.render(f"Pontuação: {pontuacao}", True, cinza_m )
    tela.blit(texto, [1, 1])

def selecionar_velocicade(tecla):
    if tecla == pygame.K_DOWN:  
        velocidade_x = 0 
        velocidade_y = tamanho_quad
    elif tecla == pygame.K_UP:
        velocidade_x = 0
        velocidade_y = - tamanho_quad
    elif tecla == pygame.K_RIGHT:
        velocidade_x = tamanho_quad
        velocidade_y = 0
    elif tecla == pygame.K_LEFT:
        velocidade_x = - tamanho_quad
        velocidade_y = 0
        
    return velocidade_x, velocidade_y

def rodar_jogo():
    fim_jogo = False
    
    x = largura / 2
    y = altura / 2
    
    velocidade_x = 0
    velocidade_y = 0
    
    tamanho_snake = 1
    pixels = []
    
    comida_x, comida_y = gerar_comida()
    
    while not fim_jogo:
        
        tela.fill(preto)
        
        for evento in pygame.event.get():
            if evento.type == pygame.QUIT:
                fim_jogo = True
            elif evento.type == pygame.KEYDOWN:
                velocidade_x, velocidade_y = selecionar_velocicade(evento.key)
        
        #atualiza a posição da cobra
        if x < 0 or x >= largura or y < 0 or y >= altura:
            fim_jogo = True
        
        x += velocidade_x
        y += velocidade_y
        
        # desenha_comida
        desenha_comida(tamanho_quad, comida_x, comida_y)
        
        # desenhar_cobra
        pixels.append([x, y])
        if len(pixels) >  tamanho_snake:
            del pixels[0]
            
        # se a cobra bateu no próprio corpo
        for pixel in pixels[:-1]:
            if pixel == [x, y]:
                fim_jogo = True
                
        desenhar_snake(tamanho_quad, pixels)
        desenhar_pontuacao(tamanho_snake - 1)
        # desenhar_pontos
        
        # atualização da tela
        pygame.display.update()
        
        # craia uma nova commida
        if x == comida_x and y == comida_y:
            tamanho_snake += 1
            comida_x, comida_y = gerar_comida()
            
        relogio.tick(game_speed)
                




# criar um loop infinito

# desenhar os objetos do jogo na tela
# pontuação
# cobrinha 

# criar a lógica de termianr o jogo
# o que acontece:
# cobrar bateu na parede
# cobra comeu o prórpio rabo (lá ele)

# pegar a interação do usuário
# fechou a tela


rodar_jogo()