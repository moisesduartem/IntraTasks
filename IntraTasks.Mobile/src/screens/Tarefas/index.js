import React, {useEffect, useState} from 'react';

import {ScrollView, Text} from 'react-native';
import {colors, ListItem} from 'react-native-elements';
import {ListItemFab} from '../../components/ListItemFab';
import {api} from '../../services/api';

import * as S from './style';

function getSituacao(id) {
  switch (id) {
    case 2:
      return 'Feito';
    default:
      return 'Pendente';
  }
}

function TarefasScreen() {
  const [items, setItems] = useState([]);

  async function fetchItems() {
    try {
      const response = await api.get('/odata/Tarefa?$count=true');
      setItems(response.data);
    } catch (err) {
      // Alert.alert('Não foi possível listar as tarefas...');
    }
  }

  useEffect(() => {
    fetchItems();
  }, []);

  return (
    <ScrollView>
      {items &&
        items?.value?.map((e, i) => (
          <ListItem key={i} bottomDivider>
            <S.Card.Container>
              <S.Card.Body>
                <S.Task.Title>{e.Titulo}</S.Task.Title>
                <S.Task.Situation situation={e.situacaoId}>
                  {getSituacao(e.situacaoId)}
                </S.Task.Situation>
                {e.observacao && (
                  <S.Note.Container>
                    <S.Note.Text>Observação</S.Note.Text>
                    <Text>{e.observacao}</Text>
                  </S.Note.Container>
                )}
              </S.Card.Body>
              <S.Item.Options>
                <S.Item.Button>
                  <ListItemFab icon="trash" color={colors.error} />
                </S.Item.Button>
                <S.Item.Button>
                  <ListItemFab icon="pencil" color={colors.primary} />
                </S.Item.Button>
                <S.Item.Button>
                  <ListItemFab icon="eye" color={colors.black} />
                </S.Item.Button>
              </S.Item.Options>
            </S.Card.Container>
          </ListItem>
        ))}
    </ScrollView>
  );
}

export {TarefasScreen};
