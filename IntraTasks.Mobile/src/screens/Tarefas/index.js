import React, {useEffect, useState} from 'react';

import {Alert, ScrollView, Text} from 'react-native';
import {colors, ListItem} from 'react-native-elements';
import {AppScreen} from '../../components/AppScreen';
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
  const [loading, setLoading] = useState(true);
  const [items, setItems] = useState([]);
  const [message, setMessage] = useState(null);

  async function fetchItems() {
    try {
      setLoading(true);
      const response = await api.get('/odata/Tarefa?$count=true');
      setTimeout(() => setItems(response.data), 50);
      setMessage(null);
      setLoading(false);
    } catch (err) {
      setMessage('Sem registros no momento...');
      setItems([]);
      setLoading(false);
    }
  }

  useEffect(() => {
    setItems([]);
    fetchItems();
  }, []);

  function handleDeleteTask(task) {
    async function sendRequest(taskId) {
      setLoading(true);
      const {data} = await api.delete(`/api/Tarefa/${taskId}`);
      Alert.alert(data.message);
      if (data.successfully) {
        fetchItems();
      }
    }

    Alert.alert(
      `Tem certeza que deseja deletar a tarefa "${task.Titulo}"?`,
      '',
      [
        {
          text: 'Não',
        },
        {
          text: 'Sim',
          onPress: () => sendRequest(task.Id.toString()),
        },
      ],
    );
  }

  return (
    <AppScreen loading={loading} message={message}>
      <ScrollView>
        {items?.value?.map((task, i) => (
          <ListItem key={i} bottomDivider>
            <S.Card.Container>
              <S.Card.Body>
                <S.Task.Title>{task.Titulo}</S.Task.Title>
                <S.Task.Situation situation={task.SituacaoId}>
                  {getSituacao(task.SituacaoId)}
                </S.Task.Situation>
                {task.observacao && (
                  <S.Note.Container>
                    <S.Note.Text>Observação</S.Note.Text>
                    <Text>{task.Observacao}</Text>
                  </S.Note.Container>
                )}
              </S.Card.Body>
              <S.Item.Options>
                <S.Item.Button>
                  <ListItemFab
                    onPress={() => handleDeleteTask(task)}
                    icon="trash"
                    color={colors.error}
                  />
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
    </AppScreen>
  );
}

export {TarefasScreen};
