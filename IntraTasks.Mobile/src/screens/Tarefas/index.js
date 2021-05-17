import React from 'react';

import {ScrollView, Text, View} from 'react-native';
import {colors, FAB, ListItem} from 'react-native-elements';
import {Icon} from 'react-native-elements';

import {situacoes, tarefas} from '../../services/data/mocked';

function getSituacaoById(id) {
  return situacoes.filter((el, i) => el.id === id)[0];
}

function TarefasScreen() {
  const buttonsSize = 15;

  return (
    <ScrollView>
      {tarefas.map((e, i) => (
        <ListItem key={i} style={styles.listItem} bottomDivider>
          <View style={styles.card}>
            <View style={styles.cardBody}>
              <Text style={styles.taskTitle}>{e.titulo}</Text>
              <Text style={styles.situacao(e)}>
                {getSituacaoById(e.situacaoId).nome}
              </Text>
              {e.observacao && (
                <View style={styles.obsContainer}>
                  <Text style={styles.obsText}>Observação</Text>
                  <Text>{e.observacao}</Text>
                </View>
              )}
            </View>
            <View style={styles.itemOptions}>
              <FAB
                icon={
                  <Icon
                    color="white"
                    size={buttonsSize}
                    name="trash"
                    type="font-awesome"
                  />
                }
                size="small"
                style={styles.fab}
                color={colors.error}
              />
              <FAB
                icon={
                  <Icon
                    color="white"
                    size={buttonsSize}
                    name="pencil"
                    type="font-awesome"
                  />
                }
                size="small"
                style={styles.fab}
                color={colors.primary}
              />
              <FAB
                icon={
                  <Icon
                    color="white"
                    size={buttonsSize}
                    name="eye"
                    type="font-awesome"
                  />
                }
                size="small"
                style={styles.fab}
                color={colors.black}
              />
            </View>
          </View>
        </ListItem>
      ))}
    </ScrollView>
  );
}

const styles = {
  taskTitle: {fontSize: 20},
  card: {padding: 5},
  cardBody: {paddingVertical: 10},
  itemOptions: {
    flexDirection: 'row',
    justifyContent: 'flex-end',
    width: '100%',
  },
  obsContainer: {paddingVertical: 10},
  obsText: {fontSize: 16, fontWeight: '700'},
  listItem: {marginVertical: 5},
  fab: {marginHorizontal: 5},
  situacao: e => ({color: e.situacaoId === 1 ? colors.error : colors.success}),
};

export {TarefasScreen};
